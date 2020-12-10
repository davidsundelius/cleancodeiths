using System;

namespace PrototypePattern
{
    class GingerbreadFigures
    {
        static void Main(string[] args)
        {
            var gingerbreadMan = new Gingerbread();
            gingerbreadMan.shape = "human";
            gingerbreadMan.name = "Hans";
            gingerbreadMan.decoration = "none";
            gingerbreadMan.width = 100.0;
            gingerbreadMan.height = 100.0;
            var gingerbreadWomen = gingerbreadMan.Clone();
            gingerbreadWomen.name = "Greta";



            /*new Gingerbread();
        gingerbreadWomen.shape = "human";
        gingerbreadWomen.name = "Greta";
        gingerbreadWomen.decoration = "none";
        gingerbreadWomen.width = 100.0;
        gingerbreadWomen.height = 100.0;*/
        }
    }
}