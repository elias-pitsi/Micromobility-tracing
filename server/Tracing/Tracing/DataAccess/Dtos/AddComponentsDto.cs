using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace Tracing.DataAccess.Dtos
{
    public class AddComponentsDto
    {
        [JsonProperty(PropertyName = "compid")]
        public Guid CompId { get; set; } = Guid.NewGuid();
        public string ComponentName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public OwnerDto owner { get; set; }
        public Guid ownerId { get; set; }
    }
}
