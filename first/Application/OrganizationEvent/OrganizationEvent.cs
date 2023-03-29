using Infrastructure.Db;
using Infrastructure.NATSConsumer;
namespace Application.OrganizationEvent
{
    public class OrganizationEvent : IOrganizationEvent
    {
        private readonly ICosumer consumer;
        private Context Organizations;

        public OrganizationEvent(ICosumer consumer)
        {
            this.consumer = consumer;
            Organizations = new Context();
        }

        public void ListenOrganizationEvent()
        {
            this.consumer.ListenToOrganization(async (id) =>
            {
                return await Organizations.GetOrganization(id);
            });
        }
    }
}
