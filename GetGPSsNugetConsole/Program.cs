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
                        Console.WriteLine("   AND (Optionally) enter API Key as second parameter.");
                        Console.WriteLine("   ... AND (Optionally) enter g as third parameter if want Google Map URL (Default Bing Map Url).");
                        return;
                    }
                    else
                    {
                        GPSData.words3 = args[0];
                        GPSData.useBing = true;
                    }
                }
                if (args.Length > 1)
                {
                    if (string.IsNullOrEmpty(args[1]))
                    {
                        if (args[1].ToLower() == "g")
                        {
                            GPSData.useBing = false;
                        }
                        else
                        {
                            GPSData.w3wkey = args[1];
                            if (args.Length > 2)
                            {
                                if (string.IsNullOrEmpty(args[2]))
                                {
                                    GPSData.useBing = (args[2].ToLower() != "g");
                                }
                            }
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
                        GPSData.lat = (double)w3wjson.coordinates.lat;
                        GPSData.lon = (double)w3wjson.coordinates.lng;
#pragma warning restore CS8629 // Nullable value type may be null.
                        if (GPSData.useBing)
                        {
                            string bingMap = GPSData.bingMap;
                            Console.WriteLine($"Bing Map Link: {bingMap}");
                            ClipboardService.SetText(bingMap);
                            Console.WriteLine("The Bing Map link URL is on the clipboard.");
                        }
                        else
                        {
                            string googleMap = GPSData.googleMap;
                            Console.WriteLine($"Google Map Link: {googleMap}");
                            ClipboardService.SetText(googleMap);
                            Console.WriteLine("The Google Map link URL is on the clipboard.");
                        }
                    }
                }
            }
        }
    }
}