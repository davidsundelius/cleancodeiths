using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new Car[] {new Car(), new Car(), new Car()};
            foreach (var car in cars)
            {
                car.brand = "Toyota";
                car.color = "blue";
                car.model = "Corolla 2020";
                car.price = 300000;
                car.topSpeed = 140;
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}