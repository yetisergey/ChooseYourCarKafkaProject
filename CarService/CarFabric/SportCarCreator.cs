using CarService.CarFabric.CarTypes;
using System.Collections.Generic;

namespace CarService.CarFabric
{
    public class SportCarCreator : CarCreator
    {
        public SportCarCreator()
        {
            cars = new List<Car>() {
                new Sport("lamborgini aventador"),
                new Sport("lamborgini huracan"),
                new Sport("lamborgini urus"),
            };

            TopicName = "getSportCar";
        }
    }
}