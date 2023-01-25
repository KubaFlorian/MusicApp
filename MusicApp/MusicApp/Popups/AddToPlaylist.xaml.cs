using MusicApp.Model;
using MusicApp.Service;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicApp.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddToPlaylist : PopupPage
    {
        private ObservableCollection<Playlists> playlistList;
        public ObservableCollection<Playlists> PlaylistList
        {
            get { return playlistList; }
            set { playlistList = value; }
        }
        private int songId;

        public AddToPlaylist(int songId)
        {
            playlistList = new ObservableCollection<Playlists>();
            this.songId = songId;
            GetPlaylists();
            InitializeComponent();
        }
        private async void GetPlaylists()
        {
            var playlistService = new PlaylistService();
            var playlists = await playlistService.GetAllPlaylists();
            foreach (var playlist in playlists)
                playlistList.Add(playlist);
        }
        private void Handle_Clicked(object sender, EventArgs e)
        {
            if (addToPlaylist.SelectedItem != null)
            {
                var selectedItem = addToPlaylist.SelectedItem as Playlists;
                InsertSong(songId, selectedItem.playlistId);
            }
            PopupNavigation.Instance.PopAsync(true);
        }
        private async void InsertSong(int songId, int playlistId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNycGJ2c3dhcXRwbm1yZ2VocWlyIiwicm9sZSI6ImFub24iLCJpYXQiOjE2NTM2NzE5MDEsImV4cCI6MTk2OTI0NzkwMX0.QaR9gZB3D7YAvG5XotcmRipnnaofhzadyvUdD_AeRu8");
            client.DefaultRequestHeaders.Add("apikey", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNycGJ2c3dhcXRwbm1yZ2VocWlyIiwicm9sZSI6ImFub24iLCJpYXQiOjE2NTM2NzE5MDEsImV4cCI6MTk2OTI0NzkwMX0.QaR9gZB3D7YAvG5XotcmRipnnaofhzadyvUdD_AeRu8");
            //var content = "[{ \"PlaylistName\": \"" + name + "\" }]";
            var stringContent = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string, string>("PlaylistId", playlistId.ToString()),
                    new KeyValuePair<string, string>("SongId", songId.ToString()),
                });
            var response = await client.PostAsync("https://crpbvswaqtpnmrgehqir.supabase.co/rest/v1/PlaylistSongs", stringContent);
        }
    }
}