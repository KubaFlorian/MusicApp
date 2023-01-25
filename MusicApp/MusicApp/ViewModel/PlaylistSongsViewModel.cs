using MusicApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicApp.ViewModel
{
    public class PlaylistSongsViewModel : BaseViewModel
    {
        public PlaylistSongsViewModel(ObservableCollection<Music> songsList, string playlistName)
        {
            this.songsList = songsList;
            this.playlistName = playlistName;
        }
        private string playlistName;
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
        public ICommand BackCommand => new Command(() => Application.Current.MainPage.Navigation.PopAsync());

        private void PlayMusic()
        {
            if (selectedMusic != null)
            {
                var viewModel = new PlayerViewModel(selectedMusic, songsList);
                var playerPage = new PlayerPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(playerPage, true);
            }
        }
    }
}
