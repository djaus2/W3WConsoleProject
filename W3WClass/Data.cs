using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3WClass
{
    public static class Data
    {
        public static string baseUrl = "https://api.what3words.com";

        public static char Seperator = '.';
        public static string requestUri
        {
            get
            {
                return $"v3/convert-to-3wa?coordinates={Data.lat}%2C{Data.lon}&key={Data.w3wkey}";
            }
        }

       

        public static string w3wkey = "";
        public static string words3 = "";
        public static double lat = 0.0;
        public static double lon = 0.0;

        public static string[] Words = new string[3];

        public static string requesGPStUri
        {
            get
            {
                return $"v3/convert-to-coordinates?words={words3}&key={Data.w3wkey}";
            }
        }
    }
}
