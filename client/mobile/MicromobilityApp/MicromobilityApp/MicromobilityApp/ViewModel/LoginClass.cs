using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MicromobilityApp.ViewModel
{
    public class LoginClass : ObservableObject
    {
        public ICommand back => new Command(() => Application.Current.MainPage.Navigation.PopAsync());
    }
}