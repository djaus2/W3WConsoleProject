using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace W3W2GPS_UWPLib
{
    public static class WhatThreeWords
    {
        public static async Task<W3W> GetW3WAsync(double lat, double lon, string w3wkey)
        {
            W3W w3w = await GetW3W(lat, lon, w3wkey);
            return w3w;
        }
        public static async Task<W3W> GetW3W(double lat, double lon, string w3wkey)
        {
            GPSData.lat = lat;
            GPSData.lon = lon;
            GPSData.w3wkey = w3wkey;

            HttpClient sharedClient = new HttpClient();
            sharedClient.BaseAddress = new Uri(GPSData.baseUrl);

            var json = await RequestW3WAsync(sharedClient);
            return json;
        }
        static async Task<W3W> RequestW3WAsync(HttpClient httpClient)
        {
            // Get it direct
            try
            {
                var jsn = await httpClient.GetFromJsonAsync<W3W>(GPSData.requestUri);
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

        public static async Task<W3W> GetGPSAsync(string words3, string w3wkey)
        {
            string[] Words = new string[0];

            if (words3.Contains(' '))
            {
                Words = words3.Split(' ');
                words3 = words3.Replace(' ', GPSData.Seperator);
            }
            else if (words3.Contains(','))
            {
                Words = words3.Split(',');
                words3 = words3.Replace(',', GPSData.Seperator);
            }
            else if (words3.Contains('.'))
            {
                Words = words3.Split('.');
                words3 = words3.Replace('.', GPSData.Seperator);
            }
            if (Words.Length == 3)
            {
                GPSData.w3wkey = w3wkey;
                GPSData.words3 = words3;
                HttpClient sharedClient = new HttpClient();
                sharedClient.BaseAddress = new Uri(GPSData.baseUrl);

                return await RequestGPSAsync(sharedClient);

            }
            else
                return null;
        }

        static async Task<W3W> RequestGPSAsync(HttpClient httpClient)
        {
            try
            {
                var jsn = await httpClient.GetFromJsonAsync<W3W>(GPSData.requesGPStUri);
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
