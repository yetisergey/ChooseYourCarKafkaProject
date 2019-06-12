using CarService.CarFabric.CarTypes;
using System.Collections.Generic;

namespace CarService.CarFabric
{
    public class CrossoverCarCreator : CarCreator
    {
        public CrossoverCarCreator()
        {
            cars = new List<Car>() {
                new Sedan("skoda yeti"),
                new Sedan("vw tiguan"),
                new Sedan("vw tuareg"),
                new Sedan("bmw x5"),
                new Sedan("bmw x6"),
            };

            TopicName = "getCrossover";
        }
    }
}
