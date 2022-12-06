using System;

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
		}

    }
}