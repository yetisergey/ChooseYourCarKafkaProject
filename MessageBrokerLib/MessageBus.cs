namespace MessageBrokerLib
{
    using Confluent.Kafka;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class MessageBus : IDisposable
    {
        private IProducer<Null, string> producer;

        private IConsumer<Null, string> consumer;

        private IEnumerable<KeyValuePair<string, string>> producerConfig;

        private IEnumerable<KeyValuePair<string, string>> consumerConfig;

        public MessageBus() : this("localhost") { }

        public MessageBus(string host)
        {
            producerConfig = new Dictionary<string, string>() {
                {"bootstrap.servers", host },
                {"group.id", Guid.NewGuid().ToString() }
            };

            consumerConfig = new Dictionary<string, string>() {
                {"group.id", "custom.group" },
                { "bootstrap.servers", host}
            };
            var builderProducer = new ProducerBuilder<Null, string>(producerConfig);
            producer = builderProducer.Build();
        }

        public void SendMessage(string topic, string message)
        {
            producer.ProduceAsync(topic, new Message<Null, string>() { Value = message });
        }

        public void Subscribe<T>(string topic, Action<T> action, CancellationToken cancellationToken) where T : class
        {
            using (var messageBus = new MessageBus())
            {
                var builderConsumer = new ConsumerBuilder<Null, string>(consumerConfig);
                messageBus.consumer = builderConsumer.Build();
                messageBus.consumer.Assign(new List<TopicPartitionOffset>() {
                        new TopicPartitionOffset(new TopicPartition(topic, new Partition(0)),-1)
                    });

                while (!cancellationToken.IsCancellationRequested)
                {
                    var res = messageBus.consumer.Consume(cancellationToken);
                    action(res.Message.Value as T);
                }
            }
        }

        public void Dispose()
        {
            if (producer != null)
            {
                producer.Dispose();
            }

            if (consumer != null)
            {
                consumer.Dispose();
            }
        }
    }
}