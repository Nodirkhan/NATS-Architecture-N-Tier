using Domain.Models;

namespace Infrastructure.NATSConsumer
{
    public interface ICosumer
    {
        void ListenToOrganization(Func<int, Task<Organization>> eventHandler);
    }
}
