using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Tracing.DataAccess.Dtos;

namespace Tracing.DataAccess.Models;

public class Bike
{
    [JsonProperty(PropertyName = "bikeid")]
    public Guid BikeId { get; set; } = Guid.NewGuid();

    public Guid OwnerId { get; set; }
    public List<BikeComponentsDto> Components { get; set; } = new();


    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

