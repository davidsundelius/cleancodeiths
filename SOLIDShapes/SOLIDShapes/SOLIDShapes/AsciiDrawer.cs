using System;

namespace SOLIDShapes
{
    public class AsciiDrawer : Drawer
    {
        public void Draw(Square s)
        {
            string result = "";
            for (int i = 0; i < s.width; i++)
            {
                for (int j = 0; j < s.width; j++)
                {
                    result += "o";
                }
                result += "\n";
            }
            Console.Write(result);
        }
    }
}