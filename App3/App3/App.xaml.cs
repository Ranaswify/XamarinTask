using App3.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    public partial class App : Application
    {
        public static string BaseURL = "https://newsapi.org/v1/";

        public App()
        {
            InitializeComponent();
            ToolbarItem toolbar = new ToolbarItem { IconImageSource = "search.png" };
            //  MainPage = new MainPage();
            MainPage = new NavigationPage(new MasterPage()) { BarBackgroundColor = Color.Black, BarTextColor = Color.White};
            MainPage.ToolbarItems.Add(toolbar);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
