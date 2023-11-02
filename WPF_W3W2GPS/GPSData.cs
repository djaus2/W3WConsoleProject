using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3W2GPS_WPF
{
    public static class GPSData
    {

        public static string w3wkey = "";
        public static double lat = 0;
        public static double lon = 0;

        public static int zoomlevel = 18;

        public static string words3 { get; internal set; }

        public static string bingMap
        {
            get
            {
                return $"https://bing.com/maps/default.aspx?cp={lat}~{lon}&lvl={zoomlevel}";
            }
        }
    }
}
