using MyNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MicromobilityApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ComponentsRegistration : ContentPage
	{
		private Client client;
        public ComponentsRegistration()
        {
            InitializeComponent();
            client = new Client(); 
        }

        private async void CompRegister(object sender, EventArgs e)
        {
            OwnerDto owner = new OwnerDto()
            {
                OwnerId = Guid.NewGuid(), // need to fetch the owner from the decoded qr code 
                Name = OwnerName.Text,
                Surname = email.Text
            };
            

            if (owner != null)
            {
                var ComponentsReg = new AddComponentsDto
                {
                    CompId = Guid.NewGuid(),
                    ComponentName = name.Text,
                    Owner = owner,
                    OwnerId = owner.OwnerId,
                };


                var comRes = client.ApiComponentsPostAsync(ComponentsReg);

                if (comRes != null)
                {
                    await Navigation.PushAsync(new MenuPage());
                }

                if (comRes != null) 
                {
                    Navigation.PushAsync(new MenuPage());
                }
            }
           
        }

        private async void ScanClicked(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushModalAsync(scan);

            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var ScannerResults = result.Text.Split(',');
                    name.Text = ScannerResults[0];
                    OwnerName.Text = ScannerResults[1];
                    surname.Text = ScannerResults[2];
                    email.Text = ScannerResults[3];


                    await Navigation.PopModalAsync();
                });
            };
        }
    }
}