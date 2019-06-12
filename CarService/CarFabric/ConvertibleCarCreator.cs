using CarService.CarFabric.CarTypes;
using System.Collections.Generic;

namespace CarService.CarFabric
{
    public class ConvertibleCarCreator : CarCreator
    {
        public ConvertibleCarCreator()
        {
            cars = new List<Car>() {
                new Sport("bmw m3"),
                new Sport("mazda mx-5"),
                new Sport("bmw z4"),
            };

            TopicName = "getConvertible";
        }
    }
}