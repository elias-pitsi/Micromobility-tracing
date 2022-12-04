using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MicromobilityApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QRCodeScanner : ContentPage
	{
		public QRCodeScanner ()
		{
			InitializeComponent ();
		}

		private async void ScanClicked(object sender, EventArgs e)
		{
			var scan = new ZXingScannerPage(); // Instakk the package
			await Navigation.PushModalAsync(scan);

			scan.OnScanResult += (result) =>
			{
				Device.BeginInvokeOnMainThread(async () =>
				{
					await Navigation.PopModalAsync();
					await DisplayAlert("Valeur QRCODE", "", result.Text, "Ok");
				});
			}; 
		}

    }
}