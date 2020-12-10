using System;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new City[] {new City(), new City(), new City()};
            cities[0].name = "Göteborg";
            cities[0].area = 243;
            cities[0].founded = 1621;
            cities[0].population = 600473;
            cities[1].name = "Stockholm";
            cities[1].area = 382;
            cities[1].founded = 1252;
            cities[1].population = 1515017;
            cities[2].name = "Malmö";
            cities[2].area = 77;
            cities[2].founded = 1250;
            cities[2].population = 321845;
            var cv = new CityVisitor();
            Console.Write(cv.SerializeCitiesToJson(cities));
        }
    }
}