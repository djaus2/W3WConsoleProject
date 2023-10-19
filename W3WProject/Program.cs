using System.Net.Http.Json;
using System.Text.Json;
using TextCopy;

namespace W3WProject
{
    internal class Program
    {
        private static HttpClient? sharedClient= null;

        const string baseUrl = "https://api.what3words.com";
        public static string requestUri = $"v3/convert-to-3wa?coordinates={Data.lat}%2C{Data.lon}&key={Data.w3wkey}";

        static async Task Main(string[] args)
        {
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