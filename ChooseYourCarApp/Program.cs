using MessageBrokerLib;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourCarKafkaProject
{
    class Program
    {
        const string messageRequest = "getCarName";
        const string topicNameResponse = "carNameResponse";

        static List<string> listCommands = new List<string>()
        {
            "getSportCar",
            "getHatchback",
            "getSedan",
            "getCrossover",
            "getConvertible",
            "getPickup"
        };


        static void Main()
        {
            using (var msgBus = new MessageBus())
            {
                Task.Run(() => msgBus.Subscribe<string>(topicNameResponse, msg => GetCarNameHandler(msg), CancellationToken.None));

                Console.WriteLine("Start consumer");

                var rnd = new Random();

                int iterator = 0;

                while (true)
                {
                    var command = listCommands[rnd.Next(0, listCommands.Count)];
                    Console.WriteLine($"Send command #{iterator} : { command }");
                    iterator++;
                    msgBus.SendMessage(command, messageRequest);
                    Thread.Sleep(1000);
                }
            }
        }

        public static void GetCarNameHandler(string msg)
        {
            Console.WriteLine($"Car: { msg } is recommended");
            
        }
    }
}