using W3WClass;
using TextCopy;

namespace GetGPS
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (string.IsNullOrEmpty(args[0]))
                {
                    if ((args[0] == "-h") || (args[0] == "--h") || (args[0] == "-help") || (args[0] == "--help") || (args[0] == "/?"))
                    {
                        Console.WriteLine("Get GPS Location from What3Words Tri-words.");
                        Console.WriteLine("Insert values in Data.cs");
                        Console.WriteLine("OR Enter dotted Triwords on command line.");
                        Console.WriteLine("   AND (Optionally) enter W3W API Key as second parameter.");
                        Console.WriteLine("   ... NB: Bing Static Maps only in this app.");
                        Console.WriteLine("   ... AND (Optionally) enter Bing Maps API Key as second parameter.");
                        return;
                    }
                    else
                    {
                        GPSData.words3 = args[0];
                    }
                }
                if (args.Length > 1)
                {
                    if (string.IsNullOrEmpty(args[1]))
                    {
                        if (args[1].Length >30)
                        {
                            GPSData.BingMapsKey = args[1];
                        }
                    }
                }

            }

            var w3wjson = await WhatThreeWords.GetGPSAsync(GPSData.words3, GPSData.w3wkey);
            if (w3wjson != null)
            {
                Console.WriteLine("Got json direct using httpClient.GetFromJsonAsync");
                Console.WriteLine("=====================================================");
                Console.WriteLine($"Latitude: {w3wjson.coordinates?.lat}");
                Console.WriteLine($"Longitude: {w3wjson.coordinates?.lng}");
                Console.WriteLine($"Country: {w3wjson.country}");
                Console.WriteLine($"Nearest Place: {w3wjson.nearestPlace}");
                Console.WriteLine($"W3W Words: {w3wjson.words}");
                Console.WriteLine("---------------------------");
                if (!string.IsNullOrEmpty(w3wjson.map))
                {
                    Console.WriteLine($"W3W Map Link: {w3wjson.map}");

                    if (w3wjson.coordinates != null)
                    {
#pragma warning disable CS8629 // Nullable value type may be null.
                        GPSData.w3w = w3wjson;
                        GPSData.lat = (double)w3wjson.coordinates.lat;
                        GPSData.lon = (double)w3wjson.coordinates.lng;
#pragma warning restore CS8629 // Nullable value type may be null.

                        string bingMap = GPSData.MapArea; // bingMap;
                        Console.WriteLine($"Bing Map Link: {bingMap}");
                        ClipboardService.SetText(bingMap);
                        Console.WriteLine("The Bing Map link URL is on the clipboard.");
                    }
                }
            }
        }
    }
}