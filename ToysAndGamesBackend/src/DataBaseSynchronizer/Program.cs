using Domain.Serializer;
using Domain.UnitOfWorkInterfaces;
using Infraestructure.UnitsOfWork;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Channels;

namespace DataBaseSynchronizer
{
    internal class Program
    {
        private readonly ISerializer _serializer;
        private readonly IUnitOfWorkCosmosDB _unitOfWorkCosmosDB;

        public Program(ISerializer serializer, IUnitOfWorkCosmosDB unitOfWorkCosmosDB)
        {
            _serializer = serializer;
            _unitOfWorkCosmosDB = unitOfWorkCosmosDB;
        }
        static void Main(string[] args)
        {
             var _connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "RichieHG",
                Password = "Unosquare"
            };

            string input;
            using IConnection connection = _connectionFactory.CreateConnection();
            using IModel channel = connection.CreateModel();

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                // copy or deserialise the payload
                // and process the message
                // ...
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);

                channel.BasicAck(ea.DeliveryTag, false);
            };
            // this consumer tag identifies the subscription
            // when it has to be cancelled
            string consumerTag = channel.BasicConsume(
                "subscription-queue",
                false, 
                consumer);
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}