using MusicApp.Model;
using MusicApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicApp.ViewModel
{
    public class RadioListViewModel : BaseViewModel
    {
        public RadioListViewModel()
        {
            radioList = new ObservableCollection<Radio>();
            GetStations();
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
        private Radio recentRadio;
        public Radio RecentRadio
        {
            get { return recentRadio; }
            set
            {
                recentRadio = value;
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

        public ICommand SelectionCommand => new Command(PlayRadio);

        private void PlayRadio(object obj)
        {
            if (selectedRadio != null)
            {
                var viewModel = new RadioPlayerViewModel(selectedRadio, radioList);
                var radioPlayerPage = new RadioPlayerPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(radioPlayerPage, true);
            }
        }

        private async void GetStations()
        {
            var radioService = new RadioService();
            var radios = await radioService.GetAllStations();
            bool first = true;
            foreach(var radio in radios)
            {
                if(first)
                {
                    radio.IsRecent = true;
                    recentRadio = radio;
                    first = false;
                }
                else
                    radio.IsRecent = false;
                radioList.Add(radio);
            }
        }
    }
}
