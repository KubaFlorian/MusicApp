using MusicApp.ViewModel;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicApp.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePlaylistPopup : PopupPage
    {
        public CreatePlaylistPopup()
        {
            InitializeComponent();
        }

        private void Handle_Clicked(object sender, EventArgs e)
        {
            if(playlistName.Text != null)
                InsertPlaylist(playlistName.Text.ToString());
            PopupNavigation.Instance.PopAsync(true);
            var viewModel = new PlaylistsViewModel();
            var playlistsPage = new PlaylistsPage { BindingContext = viewModel };

            var navigation = Application.Current.MainPage as NavigationPage;
            navigation.PushAsync(playlistsPage, true);
        }
        private async void InsertPlaylist(string name)
        {
            using (var httpClient = new HttpClient())
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNycGJ2c3dhcXRwbm1yZ2VocWlyIiwicm9sZSI6ImFub24iLCJpYXQiOjE2NTM2NzE5MDEsImV4cCI6MTk2OTI0NzkwMX0.QaR9gZB3D7YAvG5XotcmRipnnaofhzadyvUdD_AeRu8");
                client.DefaultRequestHeaders.Add("apikey", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNycGJ2c3dhcXRwbm1yZ2VocWlyIiwicm9sZSI6ImFub24iLCJpYXQiOjE2NTM2NzE5MDEsImV4cCI6MTk2OTI0NzkwMX0.QaR9gZB3D7YAvG5XotcmRipnnaofhzadyvUdD_AeRu8");
                //var content = "[{ \"PlaylistName\": \"" + name + "\" }]";
                var stringContent = new FormUrlEncodedContent(new [] {
                    new KeyValuePair<string, string>("PlaylistName", name),
                });
                var response = await client.PostAsync("https://crpbvswaqtpnmrgehqir.supabase.co/rest/v1/Playlists", stringContent);
            }
        }
    }
}