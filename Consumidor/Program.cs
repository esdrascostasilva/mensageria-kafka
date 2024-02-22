using Confluent.Kafka;


var config = new ConsumerConfig
{
    GroupId = "tuvigaDev",
    BootstrapServers = "localhost:9092"
};

using var consumer = new ConsumerBuilder<string, string>(config).Build();

// informando qual o topico o consumidor ficará conectado lendo as mensagens
consumer.Subscribe("topic_test");

// consumindo as mensagens
while (true)
{
    var result = consumer.Consume();
    Console.WriteLine($"Mensagem: {result.Message.Key} : {result.Message.Value}");
}
