using MyNamespace;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicromobilityApp.Models
{
    public class BikeCollection
    {
        public Guid BikeId { get; set; } 
        public Guid OwnerId { get; set; }
        public List<ComponentsDto> Components { get; set; }
    }
}
