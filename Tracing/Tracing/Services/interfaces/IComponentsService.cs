using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;

namespace Tracing.Services.interfaces
{
    public interface IComponentsService
    {
        Task<string> AddComponents(AddComponentsDto components);
        Task<ComponentsHistory> GetComponentHistory(string id);
        Task<IEnumerable<ComponentDetails>> GetComponents();
        Task<string> UpdateComponents(string id, AddComponentsDto components);
    }
}
