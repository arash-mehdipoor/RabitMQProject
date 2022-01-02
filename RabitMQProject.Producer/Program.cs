using RabbitMQ.Client;
using System;
using System.Text;

namespace RabitMQProject.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "InboxQueue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );

            var message = "";
            message = Console.ReadLine();

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange:"",
                routingKey: "InboxQueue",
                body: body
                );
            Console.WriteLine($"Message sent {message}");
        }
    }
}
