using System;
using System.Text.Json;

namespace VisitorPattern
{
    public class CityVisitor
    {
        public string SerializeCitiesToJson(City[] cities)
        {
            string result = "";
            foreach (var city in cities)
            {
                result += SerializeCity(city) + Environment.NewLine;
            }
            return result;
        }

        private string SerializeCity(City city)
        {
            return JsonSerializer.Serialize(city);
        }
    }
}