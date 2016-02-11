using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApi
{
    public partial class OpenWeatherMap : Form
    {
        // web service here http://openweathermap.org/current#name 
        string appKey = @"68d532a730ffc4987c9484d2f8aa80a2";
        // parameter cityId , appkey
        string url = @"http://api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}";
        // parameter weathericon 
        string weatherIcon = @"http://openweathermap.org/img/w/{0}.png";
        // parameter country 
        string countryFlag =  @"http://openweathermap.org/images/flags/{0}.png";
        public OpenWeatherMap()
        {
            InitializeComponent();
        }

        private void OpenWeatherMap_Load(object sender, EventArgs e)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(City));

            List<City> cities = new List<City>();
#if DEBUG
            using(StreamReader cityData = new StreamReader("..\\..\\StaticData\\city.list.json"))
#else
            using(StreamReader cityData = new StreamReader("StaticData\\city.list.json"))
#endif
            {
                string line;
                while(( line = cityData.ReadLine()) != null)
                {
                    using(MemoryStream lineStream  = new MemoryStream())
                    {
                        StreamWriter lineWriter = new StreamWriter(lineStream);
                        lineWriter.WriteLine(line);
                        lineWriter.Flush();
                        lineStream.Seek(0, SeekOrigin.Begin);
                        City obj = (City)serializer.ReadObject(lineStream);
                        cities.Add(obj);

                    }
                }
                
            }

            List<IGrouping<string, City>> coutries  = cities.GroupBy(c => c.country).ToList();
            coutries.Count().ToString();
            this.cmbCountries.DisplayMember = "Key";
            //this.cmbCountries.ValueMember  = "Key";
            this.cmbCountries.DataSource = coutries;
            
        }

        private void cmbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            IGrouping<string, City> records = ((ComboBox)sender).SelectedValue as IGrouping<string, City>;
            if (records == null)
                return;
            
            cmbCities.DisplayMember = "name";
            cmbCities.DataSource = records.ToList();
            
            //cmbCities.ValueMember = "_id";

        }

        private void cmbCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            City record = (City)((ComboBox)sender).SelectedValue;
            
           if(record == null)
               return;
           int citiID = record._id;

            using (WebClient client = new WebClient())
            {
                string weather = string.Format(url, citiID, appKey);
                string data = client.DownloadString(weather);
                 DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(WeatherInfo));
                 using(MemoryStream dataStream  = new MemoryStream())
                    {
                        StreamWriter lineWriter = new StreamWriter(dataStream);
                        lineWriter.Write(data);
                        lineWriter.Flush();
                        dataStream.Seek(0, SeekOrigin.Begin);
                        WeatherInfo  weatherInfo = (WeatherInfo)serializer.ReadObject(dataStream);
                        lblDescription.Text = string.Format("Description {0}",weatherInfo.weather[0].description);
                        lblTempMax.Text = string.Format("Temp Max {0}",weatherInfo.main.temp_max);
                        lblTempMin.Text = string.Format("Temp Min {0}",weatherInfo.main.temp_min);                      

                        picCountry.Load(string.Format(countryFlag, record.country.ToLower()));
                        picWeather.Load(string.Format(weatherIcon, weatherInfo.weather[0].icon));

                    }

            }
        }
    }

    #region Service classes

    /*{"coord":{"lon":34.28,"lat":44.55},
     * "weather":[{"id":800,"main":"Clear","description":"Sky is Clear","icon":"01d"}],
     * "base":"cmc stations",
     * "main":{"temp":280.558,"pressure":1017.98,"humidity":100,"temp_min":280.558,"temp_max":280.558,"sea_level":1038.23,"grnd_level":1017.98},
     * "wind":{"speed":1.81,"deg":283.5},"clouds":{"all":0},"dt":1450002895,
     * "sys":{"message":0.0106,"country":"UA","sunrise":1449983460,"sunset":1450015384},
     * "id":707860,"name":"Hurzuf","cod":200}*/

    [DataContract]
    [KnownType(typeof(Coordinate))]
    [KnownType(typeof(Weather))]
    [KnownType(typeof(Temp))]
    [KnownType(typeof(Wind))]
    public class WeatherInfo
    {
        [DataMember]
        public Coordinate coord { get; set; }
        [DataMember]
        public List<Weather> weather { get; set; }
        [DataMember]
        public Temp main { get; set;}
        [DataMember]
        public Wind wind { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }

    }

    [DataContract(Name = "Temp", Namespace = "http://www.contoso.com")]
    public class Temp
    {
        [DataMember]
        public double temp { get; set; }
        [DataMember]
        public double pressure { get; set; }
        [DataMember]
        public double temp_min { get; set; }
        [DataMember]
        public double temp_max { get; set; }
        [DataMember]
        public double humidity { get; set; }
    }

    [DataContract]
    public class Wind
    {
        [DataMember]
        public double speed { get; set; }
        [DataMember]
        public double deg { get; set; }
    }

    [DataContract(Name = "Weather", Namespace = "http://www.contoso.com")]
    public class Weather
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string main { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string icon { get; set; }
    }

    [DataContract]
    [KnownType(typeof(Coordinate))]
    public class City
    {
        //"_id":295582,"name":"‘Azriqam","country":"IL","coord":{"lon":34.700001,"lat":31.75}
        [DataMember]
        public int _id
        { get; set; }
        [DataMember]
        public string name
        { get; set; }
        [DataMember]
        public string country
        { get; set; }
        [DataMember]
        public Coordinate coord
        { get; set; }

        public string SearchName
        {
            get {
                return string.Format("{0}, {1}", this.country, this.name);
            }
        }
    }

    [DataContract]
    public class Coordinate
    {
        [DataMember]
        public double lon
        { get; set; }
        [DataMember]
        public double lat
        { get; set; }
    }
    #endregion 
}
