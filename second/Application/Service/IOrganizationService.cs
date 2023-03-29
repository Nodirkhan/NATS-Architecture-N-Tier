using Domain.Models;

namespace Application.Service
{
    public interface IOrganizationService 
    {
        Task<Organization> GetOrganizationService(int id);
    }
}
