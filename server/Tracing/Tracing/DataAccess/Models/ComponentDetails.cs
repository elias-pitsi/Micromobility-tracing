using Newtonsoft.Json;
using Tracing.DataAccess.Dtos;

namespace Tracing.DataAccess.Models
{
    public class ComponentDetails
    {
        [JsonProperty(PropertyName = "compid")]
        public Guid CompId { get; set; } = Guid.NewGuid();
        public string ComponentName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Guid OwnerId { get; set; } = Guid.NewGuid();
        public OwnerDto owner { get; set; }
        public Bike bike { get; set; }
        public Guid BikedId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
