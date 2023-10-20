using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3WClass
{
    public class W3W
    {
        // Generated at https://json2csharp.com/#:~:text=Convert%20Json%20to%20C%23%20Classes%20Online%201%20Step,second%20editor%20and%20deserialize%20using%20the%20%27Root%27%20class.
        // ... from Json after Example Result heading  in https://developer.what3words.com/public-api/docs#convert-to-3wa
        // Some mods were needed though wrt Squre class, and properties made nullable.
        public class Coordinates
        {
            public double? lng { get; set; }
            public double? lat { get; set; }
        }


        public class Square
        {
            public Coordinates? southwest { get; set; }
            public Coordinates? northeast { get; set; }
        }


        public string? country { get; set; }
        public Square? square { get; set; }
        public string? nearestPlace { get; set; }
        public Coordinates? coordinates { get; set; }
        public string? words { get; set; }
        public string? language { get; set; }
        public object? locale { get; set; }
        public string? map { get; set; }
    }
}
