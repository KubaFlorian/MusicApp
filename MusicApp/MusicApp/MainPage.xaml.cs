using MediaManager;
using MusicApp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if(CrossMediaManager.Current.IsPlaying())
                CrossMediaManager.Current.Pause();
            var viewModel = new RadioListViewModel();
            var radioPage = new RadioList { BindingContext = viewModel };

            var navigation = Application.Current.MainPage as NavigationPage;
            navigation.PushAsync(radioPage, true);
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var viewModel = new PlaylistsViewModel();
            var playlistsPage = new PlaylistsPage { BindingContext = viewModel };

            var navigation = Application.Current.MainPage as NavigationPage;
            navigation.PushAsync(playlistsPage, true);
        }

        private void addSong_Tapped(object sender, EventArgs e)
        {

        }
    }
}
