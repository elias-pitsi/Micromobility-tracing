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

        private void CompRegister(object sender, EventArgs e)
        {
            OwnerDto owner = new OwnerDto()
            {
                OwnerId = Guid.NewGuid(),
                Name = OwnerName.Text,
                Surname = email.Text
            };
            

            if (owner != null)
            {
                var OwnerID = owner.OwnerId;

                var ComponentsReg = new AddComponentsDto
                {
                    CompId = Guid.NewGuid(),
                    ComponentName = name.Text,
                    Owner = owner,
                    OwnerId = owner.OwnerId,
                };


                var comRes = client.ComponentsPOSTAsync(ComponentsReg);

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
                    await Navigation.PopModalAsync();
                    await DisplayAlert("Tracing QRCODE", "", result.Text, "Ok");
                });
            };

           // var text = scan.Result.Text.ToArray(); 
            //var textArray = text.Split('\n');
        }
    }
}