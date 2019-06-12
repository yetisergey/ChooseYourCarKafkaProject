using CarService.CarFabric.CarTypes;
using System.Collections.Generic;

namespace CarService.CarFabric
{
    public class PickupCarCreator : CarCreator
    {
        public PickupCarCreator()
        {
            cars = new List<Car>() {
                new Sedan("toyota tundra"),
                new Sedan("dodge ram"),
                new Sedan("isuzu D-MAX"),
                new Sedan("mahindra bolero pickup"),
            };

            TopicName = "getPickup";
        }
    }
}
