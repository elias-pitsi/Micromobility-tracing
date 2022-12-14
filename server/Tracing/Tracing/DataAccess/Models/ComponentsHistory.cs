using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracing.DataAccess.Dtos;

namespace Tracing.DataAccess.Models
{
    public class ComponentsHistory
    {
        [JsonProperty(PropertyName = "compid")]
        public string CompId { get; set; } = Guid.NewGuid().ToString();
        public string ComponentName { get; set; } = string.Empty;
        public List<OwnerDto> Owner { get; set; }
        public string OwnerId { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
