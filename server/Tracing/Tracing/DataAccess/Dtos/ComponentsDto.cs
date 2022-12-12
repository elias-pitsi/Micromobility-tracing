using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Tracing.DataAccess.Models;

namespace Tracing.DataAccess.Dtos
{
    public class ComponentsDto
    {
        [JsonProperty(PropertyName = "compid")]
        public string CompId { get; set; } = Guid.NewGuid().ToString();
        public string ComponentName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public OwnerDto owner { get; set; }
    }
}
