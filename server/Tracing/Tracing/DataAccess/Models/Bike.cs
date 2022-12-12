using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Tracing.DataAccess.Dtos;

namespace Tracing.DataAccess.Models;

public class Bike
{
    [JsonProperty(PropertyName = "bikeid")]
    public string BikeId { get; set; } = Guid.NewGuid().ToString();

    public string OwnerId { get; set; } = Guid.NewGuid().ToString();
    public List<BikeComponentsDto> Components { get; set; } = new();


    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

