using MusicApp.Model;
using MusicApp.Popups;
using MusicApp.Service;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            musicList = new ObservableCollection<Music>();
            GetMusics();
            //recentMusic = musicList.Where(x => x.IsRecent == true).FirstOrDefault();
        }

        ObservableCollection<Music> musicList;
        public ObservableCollection<Music> MusicList
        {
            get { return musicList; }
            set
            {
                musicList = value;
                OnPropertyChanged();
            }
        }

        private Music recentMusic;
        public Music RecentMusic
        {
            get { return recentMusic; }
            set
            {
                recentMusic = value;
                OnPropertyChanged();
            }
        }

        private Music selectedMusic;
        public Music SelectedMusic
        {
            get { return selectedMusic; }
            set
            {
                selectedMusic = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(PlayMusic);
        public ICommand AddSong => new Command(PushPopup);
        private void PushPopup(object obj)
        {
            int songId = (int)obj;
            PopupNavigation.Instance.PushAsync(new AddToPlaylist(songId));
        }

        private void PlayMusic()
        {
            if (selectedMusic != null)
            {
                var viewModel = new PlayerViewModel(selectedMusic, musicList) ;
                var playerPage = new PlayerPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(playerPage, true);
            }
        }

        private async void GetMusics()
        {
            var musicService = new MusicService();
            var songs = await musicService.GetAllSongs();
            bool first = true;
            foreach (var song in songs)
            {
                if (first)
                {
                    song.IsRecent = true;
                    recentMusic = song;
                    first = false;
                }
                else
                    song.IsRecent = false;
                musicList.Add(song);
            }
            
        }
    }
}
