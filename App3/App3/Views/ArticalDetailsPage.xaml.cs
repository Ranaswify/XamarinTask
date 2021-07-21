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
    public partial class ArticalDetailsPage : ContentPage
    {
        private Article selectedArtical;

        public ArticalDetailsPage()
        {
            InitializeComponent();
        }

        public ArticalDetailsPage(Article selectedArtical)
        {
            InitializeComponent();
            
            this.selectedArtical = selectedArtical;
            BindingContext = new ArticalDetailsViewModel(selectedArtical);
        }
    }
}