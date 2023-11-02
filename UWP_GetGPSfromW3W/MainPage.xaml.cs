using System;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using W3W2GPS_UWPLib;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace GetGPSfromW3W_UWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            GPSData.words3 = w3wTextBox.Text;
            var w3wjson = await WhatThreeWords.GetGPSAsync(GPSData.words3, GPSData.w3wkey);
            if (w3wjson != null)
            {
#pragma warning disable CS8629 // Nullable value type may be null.
                GPSData.lat = (double)w3wjson?.coordinates?.lat;
                GPSData.lon = (double)w3wjson?.coordinates?.lng;
#pragma warning restore CS8629 // Nullable value type may be null.
                string bingMap = GPSData.bingMap;
                mapTextbox.Text = $"{bingMap}";
                //Clipboard.SetContent(bingMap);
                {
                    //UWP Equivalent:
                    var dataPackage = new Windows.ApplicationModel.DataTransfer.DataPackage();
                    dataPackage.SetText(bingMap);
                    Clipboard.SetContent(dataPackage);
                }
                infoTextbox.Text = "The Bing Map link URL is on the clipboard.";
                latTextBox.Text = $"{GPSData.lat}";
                lonTextBox.Text = $"{GPSData.lon}";
                nearTextBox.Text = $"{w3wjson.nearestPlace},{w3wjson.country}";
            }
            else
            {
                var messageDialog = new MessageDialog($"Failed to get GPS Coordinates.");
                await messageDialog.ShowAsync(); ;
            }
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {

            string url = this.mapTextbox.Text;
            try
            {
                //ProcessStartInfo psInfo = new ProcessStartInfo
                //{
                //    FileName = url,
                //    UseShellExecute = true
                //};
                //Process.Start(psInfo);
                Uri uri_windows = new Uri(url);
                var options = new Windows.System.LauncherOptions();
                options.TargetApplicationPackageFamilyName = "Microsoft.MicrosoftEdge_8wekyb3d8bbwe";
                var success = await Windows.System.Launcher.LaunchUriAsync(uri_windows, options);
            }
            catch (Exception ex)
            {
                var messageDialog = new MessageDialog($"Unable to open the browser at {url}");
                await messageDialog.ShowAsync(); ;
            }
        }

    }
}