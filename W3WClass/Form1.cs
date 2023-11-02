using System;
using System.Diagnostics;
using System.Windows.Forms;
using W3WClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//#nullable disable
namespace W3WFormApp;

public partial class Form1 : Form
{

    public Form1()
    {
        InitializeComponent();
    }
    private async void convertButton_Click(object sender, EventArgs e)
    {
        if (GPSData.lat == -1000 || GPSData.lon == -1000)
        {
            MessageBox.Show("Please enter a valid latitude and longitude");
            return;
        }
        var w3wjson = await WhatThreeWords.GetW3W(GPSData.lat, GPSData.lon, GPSData.w3wkey);
        if (w3wjson != null)
        {
            string country = $"{w3wjson.country}";
            string nearest = $"{w3wjson.nearestPlace}";
            if (!string.IsNullOrEmpty(w3wjson.map))
            {
                this.locationValueLabel.Text = $"{nearest},{country}";
                this.wordsValueLabel.Text = w3wjson.words;
                Clipboard.SetDataObject(w3wjson.map);
                this.urlValueLabel.Text = w3wjson.map;
                this.infoLabel.Text = "The map link URL is also on the clipboard.";
            }
            else
                MessageBox.Show("No map link returned");
        }
        else
        {
            this.infoLabel.Text = "";
            MessageBox.Show("No map link returned");
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {

        string url = this.urlValueLabel.Text;
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

    private void inputTextBox_TextChanged(object sender, EventArgs e)
    {
        var txt = ((System.Windows.Forms.TextBox)sender).Text;
        if (int.TryParse(txt, out int val))
        {
            if (val <= 90 && val >= -90)
                GPSData.lat = val;
            else
                GPSData.lat = -1000;
        }
        else
        {
            GPSData.lat = -1000;
        }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var txt = ((System.Windows.Forms.TextBox)sender).Text;
        if (int.TryParse(txt, out int val))
        {
            if (val >= -180 && val <= 180)
                GPSData.lon = val;
            else
                GPSData.lon = -1000;
        }
        else
        {
            GPSData.lon = -1000;
        }
    }
}


