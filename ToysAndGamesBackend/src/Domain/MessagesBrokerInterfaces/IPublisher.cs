using Domain.AggregatedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MessagesBrokerInterfaces
{
    public interface IPublisher
    {
        Task PublishMessage<T>(Message<T> message, string? exchange, string? routingKey);
    }
}
