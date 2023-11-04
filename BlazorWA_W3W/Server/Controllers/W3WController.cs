using BlazorWA_W3W.Server.Controller;
using BlazorWA_W3W.Shared;
using Microsoft.AspNetCore.Mvc;
using W3WClass;


namespace BlazorWA_W3W.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class W3WController : ControllerBase
    {

        private readonly ILogger<W3WController> _logger;

        public W3WController(ILogger<W3WController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<W3WShared?> Get()
        {
            var w3wjson = await WhatThreeWords.GetW3W(SvrData.lat, SvrData.lon, SvrData.w3wkey);
            if (w3wjson != null)
            {
                W3WShared wfc = new W3WShared(w3wjson);
                return new W3WShared(wfc);
            }
            return null;
        }

            [HttpGet("{coords}")]
        public async Task<W3WShared?> Get(string coords)
        {
            if (string.IsNullOrEmpty(coords))
            {
                // Use sample data
            }
            else
            {
                string[] strings = coords.Split(',');
                if (strings.Length == 2)
                {
                    try
                    {
                        SvrData.lat = Convert.ToDouble(strings[0]);
                        SvrData.lon = Convert.ToDouble(strings[1]);
                    }
                    catch
                    {
                        return null;
                    }
                }
                else
                    return null;
            }

            var w3wjson = await WhatThreeWords.GetW3W(SvrData.lat, SvrData.lon, SvrData.w3wkey);
            if (w3wjson != null)
            {
                W3WShared wfc = new W3WShared(w3wjson);
                return new W3WShared(wfc);
            }
            return null;
        }
    }
}