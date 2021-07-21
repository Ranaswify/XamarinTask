using App3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App3.ViewModel
{
    public class ArticalDetailsViewModel : INotifyPropertyChanged
    {
        // public Article selectedArtical;
        Article _selectedArticals;
        public Article selectedArticals
        {
            set
            {
                if (_selectedArticals == value)
                    return;
                _selectedArticals = value;
                OnPropertyChanged();
            }
            get
            {
                return _selectedArticals;
            }

        }
        public ICommand OpenWebSiteCommand { get; set; }

        public ArticalDetailsViewModel(Article selectedArtical)
        {
            this.selectedArticals = selectedArtical;
            OpenWebSiteCommand = new Command(OpenWebSite);

        }

        private void OpenWebSite()
        {
            if (selectedArticals.urlToImage != null)
            {
                Uri myUri = new Uri(selectedArticals.url, UriKind.Absolute);
                Device.OpenUri(myUri);
            }
           
        }

        public ArticalDetailsViewModel()
        {
            OpenWebSiteCommand = new Command(OpenWebSite);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
