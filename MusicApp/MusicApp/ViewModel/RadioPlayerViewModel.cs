using MediaManager;
using MusicApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MusicApp.ViewModel
{
    public class RadioPlayerViewModel : BaseViewModel
    {
        public RadioPlayerViewModel(Radio selectedRadio, ObservableCollection<Radio> radioList)
        {
            this.selectedRadio = selectedRadio;
            this.radioList = radioList;
            PlayRadio(selectedRadio);
            isPlaying = true;
        }
        ObservableCollection<Radio> radioList;
        public ObservableCollection<Radio> RadioList
        {
            get { return radioList; }
            set
            {
                radioList = value;
                OnPropertyChanged();
            }
        }
        private Radio selectedRadio;
        public Radio SelectedRadio
        {
            get { return selectedRadio; }
            set
            {
                selectedRadio = value;
                OnPropertyChanged();
            }
        }
        private bool isPlaying;
        public bool IsPlaying
        {
            get { return isPlaying; }
            set
            {
                isPlaying = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PlayIcon));
            }
        }
        public string PlayIcon { get => isPlaying ? "pause.png" : "play.png"; }
        public ICommand PlayCommand => new Command(Play);
        public ICommand BackCommand => new Command(() => Application.Current.MainPage.Navigation.PopAsync());
        public ICommand ShareCommand => new Command(() => Share.RequestAsync(selectedRadio.radioUrl, selectedRadio.radioName));
        private async void Play()
        {
            if (isPlaying)
            {
                await CrossMediaManager.Current.Pause();
                IsPlaying = false; ;
            }
            else
            {
                await CrossMediaManager.Current.Play();
                IsPlaying = true; ;
            }
        }
        private async void PlayRadio(Radio radio)
        {
            var mediaInfo = CrossMediaManager.Current;
            await mediaInfo.Play(radio?.radioUrl);
            IsPlaying = true;
        }
    }
}
