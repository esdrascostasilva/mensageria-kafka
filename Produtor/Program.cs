using Confluent.Kafka;

// criar uma instancia do obj de config


var config = new ProducerConfig { BootstrapServers = "localhost:9021" };
//<chave, valor>
using var producer = new ProducerBuilder<string, string>(config).Build();

// criar obj de mensagem
var message = new Message<string, string>
{
    Key = Guid.NewGuid().ToString(),
    Value = $"Mensagem de Teste Id {Guid.NewGuid().ToString()}",
};

var result = await producer.ProduceAsync("topic_test", message);

Console.WriteLine($"{result.Offset}");
