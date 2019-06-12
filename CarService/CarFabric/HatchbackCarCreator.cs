using CarService.CarFabric.CarTypes;
using System.Collections.Generic;

namespace CarService.CarFabric
{
    public class HatchbackCarCreator : CarCreator
    {
        public HatchbackCarCreator()
        {
            cars = new List<Car>() {
                new Sport("nissan note"),
                new Sport("honda civic"),
                new Sport("kia rio")
            };

            TopicName = "getHatchback";
        }
    }
}