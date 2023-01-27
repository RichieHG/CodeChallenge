using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MessagesBrokerInterfaces
{
    public interface IPublisher
    {
        Task PublishMessage(byte[] message, string? exchange, string? routingKey);
    }
}
