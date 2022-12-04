using CommunityToolkit.Mvvm.ComponentModel;
using MicromobilityApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MicromobilityApp.ViewModel
{
    public class BaseModel : ObservableObject
    {
        public ICommand Login => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new LoginPage()));
        public ICommand Registration => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new Register()));
    }
}
