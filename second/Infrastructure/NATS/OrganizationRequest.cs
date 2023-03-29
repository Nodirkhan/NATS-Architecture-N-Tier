using System.Text;

using Domain.Models;

using NATS.Client;

using Newtonsoft.Json;

namespace Infrastructure.NATS
{
    public class OrganizationRequest : IOrganizationRequest
    {
        private readonly IConnection _connection;

        public OrganizationRequest(IConnection connection)
        {
            _connection = connection;
        }

        public async ValueTask<Organization> GetOrganization(int id)
        {
            var request = await _connection.RequestAsync(
                subject: "getOrganization",
                data: Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(id)));

            if (request.Data is null)
                return null;

            return JsonConvert
                .DeserializeObject<Organization>(Encoding.ASCII.GetString(request.Data));
        }
    }
}
