using MediaManager;
using MusicApp.Popups;
using MusicApp.ViewModel;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistsPage : ContentPage
    {
        public PlaylistsPage()
        {
            InitializeComponent();
        }

        private void createPlaylist_Tapped(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new CreatePlaylistPopup());
        }

        private void music_Tapped(object sender, EventArgs e)
        {
            var viewModel = new MainViewModel();
            var mainPage = new MainPage { BindingContext = viewModel };

            var navigation = Application.Current.MainPage as NavigationPage;
            navigation.PushAsync(mainPage, true);
        }
    }
}