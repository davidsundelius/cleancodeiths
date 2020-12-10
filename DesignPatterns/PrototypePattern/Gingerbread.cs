namespace PrototypePattern
{
    public class Gingerbread
    {
        public string shape { get; set; }
        public string decoration { get; set; }
        public string name { get; set; }
        public double width { get; set; }
        public double height { get; set; }

        public Gingerbread()
        {
            
        }

        public Gingerbread Clone()
        {
            var clone = new Gingerbread();
            clone.decoration = this.decoration;
            clone.height = this.height;
            clone.width = this.width;
            clone.name = this.name;
            clone.shape = this.shape;
            return clone;
        }
    }
}