using System.Windows.Input;
using W3WClass;

namespace NetMauiW3W
{
    public partial class MainPage : ContentPage
    {
        double latitude;
        double longitude;
        string what3wordsKey;


        W3W? W3WJson { get; set; } = null;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        void OnEntryCompletedLat(object sender, TextChangedEventArgs e)
        {
            string val = e.NewTextValue;
            if (double.TryParse(val, out double lat))
            {
                latitude = lat;
                lng.IsEnabled = true;
            }
            
        }
        void OnEntryCompletedLng(object sender, TextChangedEventArgs e)
        {
            string val = e.NewTextValue;
            if (double.TryParse(val, out double lng))
            {
                longitude = lng;
                w3wkey.IsEnabled = true;
            };
        }
        void OnEntryCompletedW3wKey(object sender, TextChangedEventArgs e)
        {
            what3wordsKey = e.NewTextValue;
            GetW2WBtn.IsEnabled= true;
        }


        private  async void OnGetWhatThreeWordsClicked(object sender, EventArgs e)
        {
            this.Busy.IsRunning = true;
            this.Busy.IsVisible = true;
            WsWJsonTable.IsVisible = false;
            var result = WhatThreeWords.GetW3W(latitude, longitude, what3wordsKey);

           var W3WJson = await result;
            if (W3WJson != null)
            {
                TC1.Text = "Country";
                TC1.Detail = $"{W3WJson.country}";
                TC2.Text = "Words";
                TC2.Detail = $"{W3WJson.words}";
                TC3.Text = "Nearest Place";
                TC3.Detail = $"{W3WJson.nearestPlace}";
                TC4.Text = "Map";
                TC4.Detail = $"{W3WJson.map}";
                this.URL.Url = W3WJson.map;
                this.URL.Text = W3WJson.words;
                TC5.Text = "Latitude";
                TC5.Detail = $"{W3WJson.coordinates.lat}";
                TC6.Text = "Longitude";
                TC6.Detail = $"{W3WJson.coordinates.lng}";
                WsWJsonTable.IsVisible = true;
                Hyper.IsVisible = true;
                GotoMap.IsVisible = true;
            }
            else
            {
                GotoMap.IsVisible = false;
                WsWJsonTable.IsVisible = false;
                Hyper.IsVisible = false;
            }
            this.Busy.IsVisible = false;
            this.Busy.IsRunning = false;

            SemanticScreenReader.Announce(GetW2WBtn.Text);
        }

        private async void OnGoToMapClicked(object sender, EventArgs e)
        {
            string Url = this.URL.Url;
            await Launcher.OpenAsync(Url);
        }
    }


    public class HyperlinkSpan : Span
    {
        public static readonly BindableProperty UrlProperty =
            BindableProperty.Create(nameof(Url), typeof(string), typeof(HyperlinkSpan), null);

        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        public HyperlinkSpan()
        {
            TextDecorations = TextDecorations.Underline;
            TextColor = Colors.Blue;
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                // Launcher.OpenAsync is provided by Essentials.
                Command = new Command(async () => 
                await Launcher.OpenAsync(Url))
            });
        }
    }
}