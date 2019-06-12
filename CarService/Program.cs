namespace CarService
{
    using CarService.CarFabric;
    using MessageBrokerLib;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        const string carResponse = "carNameResponse";

        private static MessageBus msgBus;

        private static List<CarCreator> carCreators = new List<CarCreator>()
        {
            new SedanCarCreator(),
            new SportCarCreator(),
            new PickupCarCreator(),
            new HatchbackCarCreator(),
            new CrossoverCarCreator(),
            new ConvertibleCarCreator()
        };

        static void Main(string[] main)
        {
            var exitEvent = new ManualResetEvent(false);

            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                eventArgs.Cancel = true;
                exitEvent.Set();
            };

            Console.WriteLine("Start car fabric");
            Console.WriteLine("Choose fabric:");

            var iter = 0;
            foreach (var creator in carCreators)
            {
                Console.WriteLine($"{ iter++ } {creator.TopicName}");
            }

            var creatorId = int.Parse(main.Length > 0 ? main[1] : Console.ReadLine());

            using (msgBus = new MessageBus())
            {
                Task.Run(() => msgBus.Subscribe<string>(carCreators[creatorId].TopicName,
                    (msg) =>
                    {
                        var sedan = carCreators[creatorId].GetCar();
                        msgBus.SendMessage(carResponse, sedan.Name);
                        Console.WriteLine($"Sending { sedan.Name }");
                    }, CancellationToken.None));
                exitEvent.WaitOne();
            }
        }
    }
}