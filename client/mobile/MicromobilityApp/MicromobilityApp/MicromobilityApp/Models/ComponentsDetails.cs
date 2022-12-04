using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicromobilityApp.Models
{
    public class ComponentsDetails
    {
        public Guid CompId { get; set; } 
        public string ComponentName { get; set; } = string.Empty;
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public Owner owner { get; set; }
    }
}
