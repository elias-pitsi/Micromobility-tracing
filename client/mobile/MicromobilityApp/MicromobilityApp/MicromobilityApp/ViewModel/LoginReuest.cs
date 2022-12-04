using CommunityToolkit.Mvvm.ComponentModel;
using MicromobilityApp.Models;
using MyNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MicromobilityApp.ViewModel
{
    public class LoginReuest : BaseModel
    {
        Client client = null;
        private LoginDetails login = null;

        public LoginReuest()
        {
            client = new Client();
        }

/*        public async void LoadComponents()
        {
            
        }*/
    }
}
