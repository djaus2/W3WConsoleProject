using W3WClass;
using TextCopy;

namespace WhatThreeWordsConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length > 0)
            {
                if ((args[0] == "-h") || (args[0] == "--h") || (args[0] == "-help") || (args[0] == "--help") || (args[0] == "/?"))
                {
                    Console.WriteLine("Get What3Words Tri-words for GPS location.");
                    Console.WriteLine("Insert values in Data.cs");
                    Console.WriteLine("OR Enter lattitude longitude on command line.");
                    Console.WriteLine("   AND (Optionally) enter API Key as third parameter.");
                    return;
                }
                if (args.Length > 1)
                {
                    if (double.TryParse(args[0], out double lat))
                    {
                        if (double.TryParse(args[1], out double lon))
                        {
                            GPSData.lat = lat;
                            GPSData.lon = lon;
                            if (args.Length > 2)
                            {
                                GPSData.w3wkey = args[2];
                            }
                        }
                    }
                }
            }

            var w3wjson = await WhatThreeWords.GetW3W(GPSData.lat, GPSData.lon, GPSData.w3wkey);
            if (w3wjson != null)
            {
                Console.WriteLine("Got json direct using httpClient.GetFromJsonAsync");
                Console.WriteLine("=====================================================");
                Console.WriteLine($"Country: {w3wjson.country}");
                Console.WriteLine($"Nearest Place: {w3wjson.nearestPlace}");
                Console.WriteLine($"W3W Words: {w3wjson.words}");
                Console.WriteLine("---------------------------");
                if (!string.IsNullOrEmpty(w3wjson.map))
                {
                    Console.WriteLine($"Map Link: {w3wjson.map}");
                    ClipboardService.SetText(w3wjson.map);
                    Console.WriteLine("The map link URL is on the clipboard.");
                }
            }
        }
    }
}