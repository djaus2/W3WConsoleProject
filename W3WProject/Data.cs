using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3WProject
{
    public static class Data
    {
        public static string baseUrl = "https://api.what3words.com";
        public static string requestUri
        {
            get
            {
                return $"v3/convert-to-3wa?coordinates={Data.lat}%2C{Data.lon}&key={Data.w3wkey}";
            }
        }

        public static string w3wkey = "";
        public static double lat = -37.7511;
        public static double lon = 144.9186;
    }
}
