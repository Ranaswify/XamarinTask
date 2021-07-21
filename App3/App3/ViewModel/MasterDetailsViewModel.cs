using App3.Models;
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
    public class MasterDetailsViewModel : INotifyPropertyChanged
    {
        ObservableCollection<SectionNames> _sectionNames;
        public ObservableCollection<SectionNames> sectionNames
        {
            set
            {
                if (_sectionNames == value)
                    return;
                _sectionNames = value;
                OnPropertyChanged();
            }
            get
            {
                return _sectionNames;
            }
        }
        public ICommand SelectItemsCommand { get; set; }

        public MasterDetailsViewModel()
        {
            SelectItemsCommand = new Command<SectionNames>(SelectItems);

            SectionNames sectionNames0 = new SectionNames
            {
                name = "Articals",
                icon = "explore.png"
            };

            SectionNames sectionNames1 = new SectionNames
            {
                name = "Live Chat",
                icon = "live.png"
            };

            SectionNames sectionNames2 = new SectionNames
            {
                name = "Gallery",
                icon = "gallery.png"
            };

            SectionNames sectionNames3 = new SectionNames
            {
                name = "Wish List",
                icon = "wishlist.png"
            };
            SectionNames sectionNames4 = new SectionNames
            {
                name = "Explore Online News section",
                icon = "onlineNews.png"
            };
            sectionNames = new ObservableCollection<SectionNames>();
            sectionNames.Add(sectionNames0);
            sectionNames.Add(sectionNames1);
            sectionNames.Add(sectionNames2);
            sectionNames.Add(sectionNames3);
            sectionNames.Add(sectionNames4);
        }

        private void SelectItems(SectionNames sectionName)
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
