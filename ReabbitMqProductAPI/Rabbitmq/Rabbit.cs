using RabbitMQ.Client;
using System;
using System.Text;

public class Rabbit
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public Rabbit()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost", // Ustawienia RabbitMQ
            Port = 5672
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public void PublishMessage(string message, string queueName)
    {
        _channel.QueueDeclare(queue: queueName,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(exchange: "",
                             routingKey: queueName,
                             basicProperties: null,
                             body: body);
        Console.WriteLine($" [x] Sent {message}");
    }

    ~Rabbit()
    {
        _channel.Close();
        _connection.Close();
    }
}
