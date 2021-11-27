// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();

factory.Uri = new Uri("amqps://oqunpwrq:1x7uT2QE4Orp0UJZCSR7ArLHg5XIjhqR@woodpecker.rmq.cloudamqp.com/oqunpwrq");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.QueueDeclare("hello-queue", true, false, false);

string message = "hello world";

var messageBody = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(string.Empty,"hello-queue",null,messageBody);

Console.WriteLine("The message has been sent.");

Console.ReadLine();