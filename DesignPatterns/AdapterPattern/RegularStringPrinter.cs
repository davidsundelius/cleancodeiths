using System;

namespace AdapterPattern
{
    public class RegularStringPrinter
    {
        public void PrintStringFromApi()
        {
            var api = new Base64Api();
            Console.Write(api.GetApiString());
            
        }
    }
}