namespace FactoryPattern
{
    public class Car
    {
        public string brand { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public int topSpeed { get; set; }
        public int price { get; set; }

        public override string ToString()
        {
            return "A " + color + " " + brand + " " + model + " with a top speed of " + topSpeed +
                   "km/h and a price of " + price + "SEK";
        }
    }
}