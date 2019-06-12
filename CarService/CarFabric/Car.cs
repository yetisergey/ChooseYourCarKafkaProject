namespace CarService.CarFabric
{
    public abstract class Car
    {
        public Car(string name)
        {
            Name = name;
        }
        public int Weight { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
    }
}
