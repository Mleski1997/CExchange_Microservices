using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Infrastructure.RabbitMq
{
    public class RabbitMqService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqService()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost", // Ustawienia RabbitMQ
                Port = 5672
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Deklaracja exchange
            _channel.ExchangeDeclare(exchange: "user_exchange", type: "direct");
        }

        public void PublishUserRegisteredMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "user_exchange",
                                 routingKey: "user.registered",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine($" [x] Sent {message} to exchange user_exchange with routing key user.registered");
        }

        ~RabbitMqService()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
