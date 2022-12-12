using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Tracing.DataAccess.Dtos
{
    public class BikeComponentsDto
    {
        [JsonProperty(PropertyName = "compid")]
        public string CompId { get; set; } = Guid.NewGuid().ToString();
        public string ComponentName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
