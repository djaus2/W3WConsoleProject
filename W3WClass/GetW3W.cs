using System.Net.Http.Json;
using System.Text.Json;


namespace W3WClass
{
    public static class WhatThreeWords
    {
        public static async Task<W3W?> GetW3WAsync(double lat, double lon, string w3wkey)
        {
            W3W? w3w = await GetW3W(lat, lon, w3wkey);
            return w3w;
        }
        public static async Task<W3W?> GetW3W(double lat, double lon, string w3wkey)
        {
            Data.lat = lat;
            Data.lon = lon;
            Data.w3wkey = w3wkey;

            HttpClient sharedClient = new()
            {
                BaseAddress = new Uri(Data.baseUrl)
            };
            var json = await RequestW3WAsync(sharedClient);
            return json;
        }
        static async Task<W3W?> RequestW3WAsync(HttpClient httpClient)
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
                    System.Diagnostics.Debug.WriteLine("GetFromJsonAsyn (Get 3 Word)s method didn't work");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetFromJsonAsync (Get 3 Words) method failed: {ex.Message}");
            }
            return null;

        }

        public static async Task<W3W?> GetGPSAsync(string words3, string w3wkey)
        {
            string[] Words = new string[0];

            if (words3.Contains(' '))
            {
                Words = words3.Split(' ');
                words3 = words3.Replace(' ', Data.Seperator);
            }
            else if (words3.Contains(','))
            {
                Words = words3.Split(',');
                words3 = words3.Replace(',', Data.Seperator);
            }
            else if (words3.Contains('.'))
            {
                Words = words3.Split('.');
                words3 = words3.Replace('.', Data.Seperator);
            }
            if (Words.Length == 3)
            {
                Data.w3wkey = w3wkey;
                Data.words3 = words3;
                HttpClient sharedClient = new()
                {
                    BaseAddress = new Uri(Data.baseUrl)
                };
                return await RequestGPSAsync(sharedClient);

            }
            else
                 return null; 
        }

        static async Task<W3W?> RequestGPSAsync(HttpClient httpClient)
        {
            try
            {
                var jsn = await httpClient.GetFromJsonAsync<W3W?>(Data.requesGPStUri);
                if (jsn != null)
                {
                    return jsn;

                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("GetFromJsonAsyn (Get GPS) method didn't work");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetFromJsonAsyn (Get GPS) method failed: {ex.Message}");
            }
            return null;
        }
    }
}