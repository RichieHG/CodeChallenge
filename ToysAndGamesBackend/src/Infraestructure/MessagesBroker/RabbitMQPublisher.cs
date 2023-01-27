using Domain.AggregatedModels;
using Domain.MessagesBrokerInterfaces;
using Domain.Serializer;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.MessagesBroker
{
    public class RabbitMQPublisher : IPublisher
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IConfiguration _configuration;
        private readonly ISerializer _serializer;
        public RabbitMQPublisher(
            IConfiguration configuration,
            ISerializer serializer)
        {
            _configuration = configuration;
            _connectionFactory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQ:Host"],
                UserName = _configuration["RabbitMQ:User"],
                Password = _configuration["RabbitMQ:Pass"]
            };
            _serializer = serializer;
        }

        public Task PublishMessage<T>(Message<T> message,string? exchange,string? routingKey)
        {
            using IConnection connection = _connectionFactory.CreateConnection();
            using IModel channel = connection.CreateModel();
            byte[] body = _serializer.SerializeToByteArray(message);

            channel.BasicPublish(exchange: exchange ?? "",
                                     routingKey: routingKey ?? "",
                                     basicProperties: null,
                                     body: body);
            return Task.CompletedTask;
        }
    }
}
