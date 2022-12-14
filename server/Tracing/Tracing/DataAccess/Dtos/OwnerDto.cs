using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Tracing.DataAccess.Dtos
{
    public class OwnerDto
    {
        [JsonProperty(PropertyName = "ownerid")]
        public string OwnerId { get; set; } = Guid.NewGuid().ToString(); 
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
    }
}
