using App3.Models;
using App3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        MasterDetailsViewModel masterViewModel = new MasterDetailsViewModel();

        public MasterPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = masterViewModel;
            Detail = new NavigationPage(new ArticalsPage()) { BarBackgroundColor = Color.Black, BarTextColor = Color.White };
            IsPresented = false;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string title;
            SectionNames item;
          
                var app = Application.Current as App;
                if (app != null)
                {
                    item = (SectionNames)e.SelectedItem;
                if (item == null)
                {
                }
                else
                {
                    if (item.name.Contains("Live"))
                    {
                        Detail = new NavigationPage(new LiveChatPage()) { BarBackgroundColor = Color.Black, BarTextColor = Color.White };
                        IsPresented = false;

                    }
                    else if (item.name == "Gallery")
                    {
                        Detail = new NavigationPage(new GalleryPage()) { BarBackgroundColor = Color.Black, BarTextColor = Color.White };
                        IsPresented = false;

                    }
                    else if (item.name.Contains("Explore"))
                    {

                        Detail = new NavigationPage(new ExploreOnlineNewsPage()) { BarBackgroundColor = Color.Black, BarTextColor = Color.White };
                        IsPresented = false;
                    }
                    else if (item.name.Contains("Wish"))
                    {

                        Detail = new NavigationPage(new WishListPage()) { BarBackgroundColor = Color.Black, BarTextColor = Color.White };
                        IsPresented = false;
                    }
                    else
                    {
                        Detail = new NavigationPage(new ArticalsPage()) { BarBackgroundColor = Color.Black, BarTextColor = Color.White };
                        IsPresented = false;
                    }
                }

                }
            
        }
    }
}