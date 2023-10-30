using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3WClass
{
    public static class GPSData
    {

        public static string w3wkey = "";
        public static string words3 = "decorators.storybook.twisty";
        public static double lat = 0.0;
        public static double lon = 0.0;
        public static bool useBing = true;

        public static string bingMap
        {
            get
            {
                return $"https://bing.com/maps/default.aspx?cp={lat}~{lon}";
            }
        }

        public static string googleMap
        {
            get
            {
                return $"https://www.google.com/maps/@{lat},{lon},14z";
            }
        }
    }
}
