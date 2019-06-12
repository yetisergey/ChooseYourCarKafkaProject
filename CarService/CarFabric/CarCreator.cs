using System;
using System.Collections.Generic;

namespace CarService.CarFabric
{
    public abstract class CarCreator
    {
        public string TopicName { get; set; }

        private static Random random = new Random();

        public List<Car> cars;

        public Car GetCar()
        {
            if (cars == null)
                throw new Exception($"cars is null {this.GetType()}");
            return cars[random.Next(0, cars.Count)];
        }
    }
}
