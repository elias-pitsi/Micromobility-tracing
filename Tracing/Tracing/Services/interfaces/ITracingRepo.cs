using Tracing.DataAccess.Models;

namespace Tracing.Services.interfaces
{
    public interface ITracingRepo
    {
        void CreateOwner(Owner owner); 
     
        Owner GetOwnerByEmail(string email);
        IEnumerable<Owner> GetOwnerItems();
    }
}
