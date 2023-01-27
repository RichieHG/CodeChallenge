using Domain.MessagesBrokerInterfaces;
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
        public RabbitMQPublisher(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionFactory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQ:Host"],
                UserName = _configuration["RabbitMQ:User"],
                Password = _configuration["RabbitMQ:Pass"]
            };
        }

        public Task PublishMessage(byte[] message,string? exchange,string? routingKey)
        {
            using IConnection connection = _connectionFactory.CreateConnection();
            using IModel channel = connection.CreateModel();
            channel.BasicPublish(exchange: exchange ?? "",
                                     routingKey: routingKey ?? "",
                                     basicProperties: null,
                                     body: message);
            return Task.CompletedTask;
        }
    }
}
