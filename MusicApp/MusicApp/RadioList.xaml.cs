using MediaManager;
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
    public partial class RadioList : ContentPage
    {
        public RadioList()
        {
            InitializeComponent();
        }

        private void radio_Tapped(object sender, EventArgs e)
        {
            if (CrossMediaManager.Current.IsPlaying())
                CrossMediaManager.Current.Pause();
            var viewModel = new MainViewModel();
            var mainPage = new MainPage { BindingContext = viewModel };

            var navigation = Application.Current.MainPage as NavigationPage;
            navigation.PushAsync(mainPage, true);
        }
    }
}