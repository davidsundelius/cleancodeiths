using System;
using System.Transactions;

namespace SOLIDShapes
{
    public class Square : Shape2D
    {
        public double width { get; }

        private string type = "Square";

        public Square()
        {
            
        }

        public Square(double width)
        {
            this.width = width;
        }

        public double GetArea()
        {
            return this.width * this.width;
        }

        public void draw(Drawer d)
        {
            d.Draw(this);
        }
    }
}