using MusicApp.ViewModel;
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
    public partial class PlaylistSongsPage : ContentPage
    {
        public PlaylistSongsPage()
        {
            InitializeComponent();
        }

        private void add_Tapped(object sender, EventArgs e)
        {

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