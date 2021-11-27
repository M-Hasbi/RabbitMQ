// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Linq;
using System.Text;

var factory = new ConnectionFactory();

factory.Uri = new Uri("amqps://oqunpwrq:1x7uT2QE4Orp0UJZCSR7ArLHg5XIjhqR@woodpecker.rmq.cloudamqp.com/oqunpwrq");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.QueueDeclare("hello-queue", true, false, false);

Enumerable.Range(1, 50).ToList().ForEach(x =>
{
    string message = $"The message {x}";

    var messageBody = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(string.Empty, "hello-queue", null, messageBody);

    Console.WriteLine($"The {message} message has been sent.");
});

Console.ReadLine();