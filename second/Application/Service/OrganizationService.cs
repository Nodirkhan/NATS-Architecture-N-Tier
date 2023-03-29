using Domain.Models;

using Infrastructure.NATS;

namespace Application.Service
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRequest _organizationRequest;
        public OrganizationService(
            IOrganizationRequest organizationRequest)
        {
            _organizationRequest= organizationRequest;
        }
        public async Task<Organization> GetOrganizationService(int id)
        {
            return await _organizationRequest.GetOrganization(id);
        }
    }
}
