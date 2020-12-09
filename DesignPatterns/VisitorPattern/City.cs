using System.Text.Json;

namespace VisitorPattern
{
    public class City
    {
        public string name{ get; set; }
        public int population{ get; set; }
        public int area{ get; set; }
        public int founded { get; set; }

        public City()
        {
            
        }

        public string exportToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}