using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WeatherForecast
{
    public partial class Form1 : Form
    {
        WeatherService.GlobalWeatherSoapClient client = new WeatherService.GlobalWeatherSoapClient(@"GlobalWeatherSoap");
        public Form1()
        {
            InitializeComponent();

            string cities = client.GetCitiesByCountry("Bulgaria");
            DataSet CitiesSet = new DataSet();

            using (MemoryStream Stream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(cities)))
            {
                CitiesSet.ReadXml(Stream);
            }
            comboBox1.DataSource = CitiesSet.Tables[0];
            comboBox1.DisplayMember = "City";
            comboBox1.ValueMember = "City";
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DataRowView rowView = this.comboBox1.SelectedItem as DataRowView;
            if (rowView == null && string.IsNullOrEmpty((string)rowView["City"]))
                return;

            string weather = client.GetWeather((string)rowView["City"], "Bulgaria");

            CurrentWeather addresses = null;

            using (MemoryStream Stream = new MemoryStream(UTF8Encoding.Unicode.GetBytes(weather)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CurrentWeather));

                addresses = (CurrentWeather)serializer.Deserialize(Stream);
            }
            this.label1.Text = addresses.ToString();
            
        }
    }
}
