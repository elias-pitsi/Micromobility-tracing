using System.Windows.Input;
using Xamarin.Forms;

namespace MicromobilityApp.ViewModel
{
    public class RegistrationClass
    {
        public ICommand back => new Command(() => Application.Current.MainPage.Navigation.PopAsync());
    }
}
