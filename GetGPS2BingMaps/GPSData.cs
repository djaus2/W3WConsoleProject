using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3WClass
{
    public static class GPSData
    {
        // Sample: Regional Victoria/Australia near Maldon.
        public static string words3 = "adjust.case.trains";

        // Ref: W3W API Key and Docs
        public static string w3wkey = "";

        // Ref: Get a Map API Key from : https://www.bingmapsportal.com/
        // Ref: https://learn.microsoft.com/en-us/bingmaps/rest-services/imagery/get-a-static-map
        public static string BingMapsKey = "";

        public static W3W w3w;
        public static double lat = 0.0;
        public static double lon = 0.0;

        public static string format = "png";//gif,jpeg
        public static string centerpoint
        {
            get{
                return $"{lat },{lon }";
            }
        }
        public static string pushpinLocation
        {
            get
            {
                return centerpoint;
            }
        }


        public static int zoomlevel = 18;
        public static int ppStyle = 36;
        public static int mapWidth = 800;
        public static string maptype = "Road";//Aerial
        public static string MapArea
        {
            get
            {
                return
                    $"https://dev.virtualearth.net/REST/v1/Imagery/Map/{maptype}/{centerpoint}/{zoomlevel}?" +
                    $"mapSize={mapWidth},{mapWidth}" +
                    $"&pp={pushpinLocation};{ppStyle}" +
                    $"&mapLayer=Basemap,Buildings" +
                    $"&key={BingMapsKey}";
            }
        }
    
    }
}
