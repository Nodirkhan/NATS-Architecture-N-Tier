using System.Text;
using Domain.Models;
using NATS.Client;
using Newtonsoft.Json;

namespace Infrastructure.NATSConsumer
{
    public class Consumer : ICosumer
    {
        private readonly IConnection _connection;
        public Consumer(IConnection connection)
        {
            _connection= connection;
        }

        public void ListenToOrganization(Func<int, Task<Organization>> eventHandler)
        {
            EventHandler<MsgHandlerEventArgs> messageHandler = CreateFunctionEvent(eventHandler);
            _connection.SubscribeAsync("getOrganization", "load-balancing-queue", messageHandler);
        }

        private EventHandler<MsgHandlerEventArgs> CreateFunctionEvent(
            Func<int, Task<Organization>> handler)
        {
            return async (sender, e) =>
            {
                var id = JsonConvert.DeserializeObject<int>(Encoding.ASCII.GetString(e.Message.Data));
                var organization = await handler(id);

                _connection.Publish(e.Message.Reply, Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(organization)));
            };
        }
    }
}
