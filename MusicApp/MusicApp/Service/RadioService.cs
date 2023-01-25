using MusicApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Service
{
    public class RadioService
    {
        public async Task<List<Radio>> GetAllStations()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNycGJ2c3dhcXRwbm1yZ2VocWlyIiwicm9sZSI6ImFub24iLCJpYXQiOjE2NTM2NzE5MDEsImV4cCI6MTk2OTI0NzkwMX0.QaR9gZB3D7YAvG5XotcmRipnnaofhzadyvUdD_AeRu8");
            httpClient.DefaultRequestHeaders.Add("apikey", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNycGJ2c3dhcXRwbm1yZ2VocWlyIiwicm9sZSI6ImFub24iLCJpYXQiOjE2NTM2NzE5MDEsImV4cCI6MTk2OTI0NzkwMX0.QaR9gZB3D7YAvG5XotcmRipnnaofhzadyvUdD_AeRu8");
            var json = await httpClient.GetStringAsync("https://crpbvswaqtpnmrgehqir.supabase.co/rest/v1/Radio?select=*");
            return JsonConvert.DeserializeObject<List<Radio>>(json);
        }
    }
}
