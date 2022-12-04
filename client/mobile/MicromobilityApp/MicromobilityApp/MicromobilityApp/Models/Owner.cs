using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicromobilityApp.Models
{
    public class Owner
    {
        [JsonProperty(PropertyName = "ownerid")]
        public Guid OwnerId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        [EmailAddress]
        public string email { get; set; } = string.Empty;
    }
}
