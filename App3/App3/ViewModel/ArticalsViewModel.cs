using App3.Helper;
using App3.Models;
using App3.Services;
using App3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App3.ViewModel
{
    public class ArticalsViewModel : INotifyPropertyChanged
    {
        ArticalsServices articalService = new ArticalsServices();
        ObservableCollection<Article> _articals;
        public ObservableCollection<Article> articals
        {
            set
            {
                if (_articals == value)
                    return;
                _articals = value;
                OnPropertyChanged();
            }
            get
            {
                return _articals;
            }
        }


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


        bool _isArticalSelected;
        public bool isArticalSelected
        {
            set
            {
                if (_isArticalSelected == value)
                    return;
                _isArticalSelected = value;
                OnPropertyChanged();
            }
            get
            {
                return _isArticalSelected;
            }
        }


        bool _IsLoading;
        public bool IsLoading
        {
            set
            {
                if (_IsLoading == value)
                    return;
                _IsLoading = value;
                OnPropertyChanged();
            }
            get
            {
                return _IsLoading;
            }
        }

        public ICommand SelectedArticalCommand { get; set; }

        public ArticalsViewModel()
        {
            articals = new ObservableCollection<Article>();
            SelectedArticalCommand = new Command(async () => { await SelectedArtical(); });
            GetAll();
        }
       
        private async Task SelectedArtical()
        {
            await App.Current.MainPage.Navigation.PushAsync(new ArticalDetailsPage(selectedArticals));
            
        }

        private async Task GetAll()
        {
            try
            {
                IsLoading = true;

                var response = await articalService.GetArticals("associated-press", "1c0f731cca954a13875e6965f9c7e9de");

                if (response != null)
                {
                    articals = response.articles;
                    var response2 = await articalService.GetArticals("the-next-web", "1c0f731cca954a13875e6965f9c7e9de");
                    if (response2 != null)
                    {
                        foreach (var i in response2.articles)
                        {
                            articals.Add(i);
                        }
                    }
                    
                    IsLoading = false;
                    isArticalSelected = true;
                }

            }
            catch (Exception ex)
            {
                IsLoading = false;
                isArticalSelected = true;
            }
         
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
