using CarService.CarFabric.CarTypes;
using System.Collections.Generic;

namespace CarService.CarFabric
{
    public class SedanCarCreator : CarCreator
    {
        public SedanCarCreator()
        {
            cars = new List<Car>() {
                new Sedan("lada granta"),
                new Sedan("vaz 2105"),
                new Sedan("vaz 2107"),
                new Sedan("lada priora"),
            };

            TopicName = "getSedan";
        }
    }
}
