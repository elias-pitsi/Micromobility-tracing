using MyNamespace;
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
    public partial class Register : ContentPage
    {
        private Client client;
        public Register()
        {
            InitializeComponent();
            client= new Client();
        }

        private async void HandleRegister(object sender, EventArgs args)
        {
            OwnerRegistrationDto register = new OwnerRegistrationDto()
            {
                Name = name.Text,
                Surname= surname.Text,
                Email= email.Text,
                Password = Password.Text,
                ConfirmPassword = ConfirmPassword.Text,
            };

            var getRegistration = await client.ApiAuthenticationRegisterAsync(register);

            if (getRegistration.Success == true) 
            {
                await Navigation.PushAsync(new LoginPage());
            }
        }
    }
}