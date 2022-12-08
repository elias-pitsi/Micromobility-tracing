using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace Tracing.DataAccess.Dtos
{
    public class BikeDto
    {
        [JsonProperty(PropertyName = "bikeid")]
        public Guid BikeId { get; set; } = Guid.NewGuid();

        public Guid OwnerId { get; set; }
        public List<BikeComponentsDto> Components { get; set; }
    }
}
