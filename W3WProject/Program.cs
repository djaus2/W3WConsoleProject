using System.Net.Http.Json;
using System.Text.Json;
using TextCopy;

namespace W3WProject
{
    internal class Program
    {
        private static HttpClient? sharedClient= null;

        static async Task Main(string[] args)
        {
             if (args.Length>0)
            {
                if ((args[0]=="-h") || (args[0] == "--h") || (args[0] == "-help") || (args[0] == "--help") || (args[0] == "/?"))
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
                            Data.lat = lat;
                            Data.lon = lon;
                            if (args.Length > 2)
                            {
                                Data.w3wkey = args[2];
                            }
                        }
                    }
                }
            }
            // https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient
            Console.WriteLine("Hi from Word3Word App!");
            // HttpClient lifecycle management best practices:
            // https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
            HttpClient sharedClient = new()
            {
                BaseAddress = new Uri(Data.baseUrl),
            };
            await GetAsync(sharedClient);
        }



        static async Task GetAsync(HttpClient httpClient)
        {
            // Get it the long way
            Console.WriteLine("Getting json string using httpClient.GetAsync");
            Console.WriteLine("=====================================================");
            try
            {
                using HttpResponseMessage response = await httpClient.GetAsync(Data.requestUri);
                var check = response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"json string: {jsonResponse}");
                var json = JsonSerializer.Deserialize<W3W>(jsonResponse);
                Console.WriteLine("---------------------------");
                Console.WriteLine($"json string parsed OK\n");
                // Could print properties here as below but once is enough.
            } catch (Exception ex)
            {
                Console.WriteLine($"GetAsync method failed: {ex.Message}");
            }

            // Get it direct
            try
            {
                var jsn = await httpClient.GetFromJsonAsync<W3W>(Data.requestUri);
                if (jsn != null)
                {
                    Console.WriteLine("Getting json direct using httpClient.GetFromJsonAsync");
                    Console.WriteLine("=====================================================");
                    Console.WriteLine($"Country: {jsn.country}");
                    Console.WriteLine($"Nearest Place: {jsn.nearestPlace}");
                    Console.WriteLine($"W3W Words: {jsn.words}");
                    Console.WriteLine("---------------------------");
                    if (!string.IsNullOrEmpty(jsn.map))
                    {
                        Console.WriteLine($"Map Link: {jsn.map}");
                        ClipboardService.SetText(jsn.map);
                        Console.WriteLine("The map link URL is on the clipboard.");
                    }
                }
                else
                {
                    Console.WriteLine("GetFromJsonAsync method didn't work");
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"GetFromJsonAsync method failed: {ex.Message}");
            }


        }
    }
}