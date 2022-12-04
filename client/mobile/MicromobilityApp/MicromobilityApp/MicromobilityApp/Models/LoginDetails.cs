using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicromobilityApp.Models
{
    public class LoginDetails
    {
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}
