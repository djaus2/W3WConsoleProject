using System.Diagnostics.Contracts;
using W3WClass;

namespace BlazorWA_W3W.Shared
{
    public class W3WShared : W3W
    {
        // Create drived class so teh dll isn't required on the class
        public W3WShared()
        {
        }
        public W3WShared(W3W w3w)
        {
            this.words = w3w.words;
            this.country = w3w.country;
            this.coordinates = w3w.coordinates;
            this.nearestPlace = w3w.nearestPlace;
            this.map = w3w.map;

            if (w3w.language != null)
                this.language = w3w.language;
            if (w3w.locale != null)
                this.locale = w3w.locale;

            if (w3w.square != null)
            { 
                if (w3w.square.northeast != null && w3w.square.southwest != null)
                {
                    this.square = w3w.square;
                }
            }
        }

    }
}