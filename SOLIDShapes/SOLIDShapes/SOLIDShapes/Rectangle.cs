using System;

namespace SOLIDShapes
{
    public class Rectangle : Shape2D
    {
        private double width;
        private double height;

        public Rectangle()
        {
            
        }
        
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double GetArea()
        {
            return this.height * this.width;
        }

        public double GetHeight()
        {
            return this.height;
        }
    }
}