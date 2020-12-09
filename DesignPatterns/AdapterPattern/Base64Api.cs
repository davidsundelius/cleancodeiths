using System;
using System.Text;

namespace AdapterPattern
{
    public class Base64Api
    {
        private const string secretString = "Secret Message";

        public string GetApiString()
        {
            return ConvertStringToBase64(secretString);
        }
        
        private string ConvertStringToBase64(string message)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(message));
            //Convert.FromBase64String(message);
        }

        public string ConvertBase64ToString(string base64)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }
    }
}