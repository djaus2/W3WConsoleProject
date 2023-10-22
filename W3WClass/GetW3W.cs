using System.Net.Http.Json;
using System.Text.Json;


namespace W3WClass
{
    public static class WhatThreeWords
    {
        public static async Task<W3W?> GetW3W(double lat, double lon, string w3wkey)
        {
            Data.lat = lat;
            Data.lon = lon;
            Data.w3wkey = w3wkey;

            HttpClient sharedClient = new()
            {
                BaseAddress = new Uri(Data.baseUrl)
            };
            var json = await GetAsync(sharedClient);
            return json;
        }
        static async Task<W3W?> GetAsync(HttpClient httpClient)
        {
            // Get it direct
            try
            {
                var jsn = await httpClient.GetFromJsonAsync<W3W>(Data.requestUri);            
                if (jsn != null)
                {
                    return jsn;

                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("GetFromJsonAsync method didn't work");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetFromJsonAsync method failed: {ex.Message}");
            }
            return null;

        }
    }
}