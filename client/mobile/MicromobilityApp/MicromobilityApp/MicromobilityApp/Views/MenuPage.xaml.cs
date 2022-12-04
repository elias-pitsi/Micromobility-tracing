using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MicromobilityApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : FlyoutPage
    {
        public MenuPage()
        {
            InitializeComponent();
            Flyout.listview.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;
            if (item != null)
            {
                Detail = (Page)Activator.CreateInstance(item.TargetPage);
                Flyout.listview.SelectedItem = null;
                IsPresented= false;
            }
        }
    }
}