using Domain.Models;

namespace Infrastructure.NATS
{
    public interface IOrganizationRequest
    {
        ValueTask<Organization> GetOrganization(int id);
    }
}
