using System;

namespace SOLIDShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Square r = new Square(4);
            r.draw(new AsciiDrawer());
        }
    }
}
