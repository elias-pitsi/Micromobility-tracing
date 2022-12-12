using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;

namespace Tracing.Services.interfaces
{
    public interface IBikeService
    {
        Task<IEnumerable<Bike>> GetBikes();
        Task<string> AddBikes(BikeDto bike);
    }
}
