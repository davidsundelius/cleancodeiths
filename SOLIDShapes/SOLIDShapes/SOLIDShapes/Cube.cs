namespace SOLIDShapes
{
    public class Cube : Shape3D
    {
        private double width;

        public Cube()
        {
            this.width = width;
        }

        public double GetVolume()
        {
            return width * width * width;
        }

        public double GetMantleArea()
        {
            return width * width * 6;
        }
    }
}