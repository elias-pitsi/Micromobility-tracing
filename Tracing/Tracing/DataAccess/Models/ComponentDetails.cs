using Newtonsoft.Json;
using Tracing.DataAccess.Dtos;

namespace Tracing.DataAccess.Models
{
    public class ComponentDetails
    {
        [JsonProperty(PropertyName = "compid")]
        public string CompId { get; set; } = Guid.NewGuid().ToString();
        public string ComponentName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string OwnerId { get; set; } = Guid.NewGuid().ToString();
        public OwnerDto owner { get; set; }
        public Bike bike { get; set; }
        public string BikedId { get; set; } = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
