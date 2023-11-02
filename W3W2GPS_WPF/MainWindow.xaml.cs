using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using W3WClass;

namespace W3W2GPS_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
                mapTextbox.Text =$"{bingMap}";
                Clipboard.SetText(bingMap);
                infoTextbox.Text = "The Bing Map link URL is on the clipboard.";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string url = this.mapTextbox.Text;
            try
            {
                ProcessStartInfo psInfo = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open the browser at {url}");
            }
        }

    }
}
