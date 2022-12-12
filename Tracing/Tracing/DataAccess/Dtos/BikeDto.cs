using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace Tracing.DataAccess.Dtos
{
    public class BikeDto
    {
        [JsonProperty(PropertyName = "bikeid")]
        public string BikeId { get; set; } = Guid.NewGuid().ToString();

        public string OwnerId { get; set; } = Guid.NewGuid().ToString();
        public List<BikeComponentsDto> Components { get; set; }
    }
}
