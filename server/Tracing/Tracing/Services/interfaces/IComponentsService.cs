using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;

namespace Tracing.Services.interfaces
{
    public interface IComponentsService
    {
        Task<string> AddComponents(AddComponentsDto components);
        Task<ComponentsHistory> GetComponentHistory(Guid id);
        Task<IEnumerable<ComponentDetails>> GetComponents();
        Task<string> UpdateComponents(Guid id, AddComponentsDto components);
        Task<string> DeleteComponent(Guid compId);
    }
}
