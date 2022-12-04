
using MyNamespace;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MicromobilityApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		private Client client;
		public LoginPage ()
		{
			client = new Client();
			InitializeComponent();
		}

        private async void HandleLogin(object sender, EventArgs e)
		{ 
			OwnerLoginDto owner = new OwnerLoginDto()
			{ 
				Email = Email.Text,
				Password = Password.Text
			};

			var getLogin = await client.ApiAuthenticationLoginAsync(owner);
			
			if(getLogin.Token != "Wrong Credentials! Please check your username or password")
			{
                App.Current.Properties["IsLogged"] = getLogin;
                await Navigation.PushAsync(new MenuPage());

            }
        }
    }
}