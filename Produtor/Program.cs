using Confluent.Kafka;

// criar uma instancia do obj de config


var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
//<chave, valor>
using var producer = new ProducerBuilder<string, string>(config).Build();

// criar obj de mensagem
var message = new Message<string, string>
{
    Key = Guid.NewGuid().ToString(),
    Value = $"Mensagem de Teste {DateTime.Now}",
};

var result = await producer.ProduceAsync("topic_test", message);

Console.WriteLine($"Offset: {result.Offset}");
