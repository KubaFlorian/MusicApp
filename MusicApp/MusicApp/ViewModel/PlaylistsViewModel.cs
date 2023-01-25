using MusicApp.Model;
using MusicApp.Service;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicApp.ViewModel
{
    public class PlaylistsViewModel : BaseViewModel
    {
        public PlaylistsViewModel()
        {
            playlistsList = new ObservableCollection<Playlists>();
            playlistsRelations = new ObservableCollection<PlaylistSongs>();
            songsList = new ObservableCollection<Music>();
            playlistSongs = new ObservableCollection<Music>();
            GetPlaylists();
        }

        private ObservableCollection<Music> playlistSongs;
        public ObservableCollection<Music> PlaylistSongs
        {
            get { return playlistSongs; }
            set
            {
                playlistSongs = value;
                OnPropertyChanged();
            }
        }
        ObservableCollection<Playlists> playlistsList;
        public ObservableCollection<Playlists> PlaylistsList
        {
            get { return playlistsList; }
            set
            {
                playlistsList = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<PlaylistSongs> playlistsRelations;
        public ObservableCollection<PlaylistSongs> PlaylistsRelations
        {
            get { return playlistsRelations; }
            set
            {
                playlistsRelations = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Music> songsList;
        public ObservableCollection<Music> SongsList
        {
            get { return songsList; }
            set 
            { 
                songsList = value;
                OnPropertyChanged();
            }
        }

        private Playlists selectedPlaylist;
        public Playlists SelectedPlaylist
        {
            get { return selectedPlaylist; }
            set
            {
                selectedPlaylist = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(OpenPlaylist);

        private void OpenPlaylist()
        {
            if (selectedPlaylist != null)
            {
                foreach (var item in playlistsRelations)
                {
                    if (item.playlistId == selectedPlaylist.playlistId)
                    {
                        foreach (var song in songsList)
                        {
                            if (song.songId == item.songId)
                                playlistSongs.Add(song);
                        }
                    }
                }
                var viewModel = new PlaylistSongsViewModel(playlistSongs, selectedPlaylist.playlistName);
                var playlistSongsPage = new PlaylistSongsPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(playlistSongsPage, true);
            }
        }

        private async void GetPlaylists()
        {
            var playlistService = new PlaylistService();
            var playlists = await playlistService.GetAllPlaylists();
            foreach (var playlist in playlists)
                playlistsList.Add(playlist);
            var songs = await playlistService.GetPlaylistSongs();
            foreach (var song in songs)
                playlistsRelations.Add(song);
            var musicService = new MusicService();
            var musics = await musicService.GetAllSongs();
            foreach (var music in musics)
                songsList.Add(music);
        }
    }
}
