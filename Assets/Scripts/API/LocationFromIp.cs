using UnityEngine;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;


    public class LocationFromIp : MonoBehaviour
    {
        public static string getIp()
        {
            string myIP = new WebClient().DownloadString("https://icanhazip.com/");
            return myIP;
        }

        public class LocationInfo
        {
            public string ip { get; set; }
            public string country_code { get; set; }
            public string country_name { get; set; }
            public string region_code { get; set; }
            public string region_name { get; set; }
            public string city { get; set; }
            public string zip_code { get; set; }
            public string time_zone { get; set; }
            public float latitude { get; set; }
            public float longitude { get; set; }
        }

        public static LocationInfo GetLocationInfo(string ipAddress)
        {
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString($"http://ip-api.com/json/{ipAddress}");
                return JsonConvert.DeserializeObject<LocationInfo>(json);
            }
        }
        public static float getWeatherInfo()
        {
            var locationInfo = GetLocationInfo(getIp());
            var weatherInfo =  GetWeatherInfoAsync(locationInfo.city);
            return weatherInfo.current.condition.code;
        }
        public class WeatherInfo
        {
            public Location location { get; set; }
            public Current current { get; set; }
        }

        public class Current
        {
            public float last_updated_epoch { get; set; }
            public string last_updated { get; set; }
            public float temp_c { get; set; }
            public float temp_f { get; set; }
            public float is_day { get; set; }
            public Condition condition { get; set; }
            public float wind_mph { get; set; }
            public float wind_kph { get; set; }
            public float wind_degree { get; set; }
            public string wind_dir { get; set; }
            public float pressure_mb { get; set; }
            public float pressure_in { get; set; }
            public float precip_mm { get; set; }
            public float precip_in { get; set; }
            public float humidity { get; set; }
            public float cloud { get; set; }
            public float feelslike_c { get; set; }
            public float feelslike_f { get; set; }
            public float vis_km { get; set; }
            public float vis_miles { get; set; }
            public float uv { get; set; }
            public float gust_mph { get; set; }
            public float gust_kph { get; set; }
            
        }

        public class Condition
        {
            public string text { get; set; }
            public string icon { get; set; }
            public float code { get; set; }
        }

        public class Location
        {
            public string name { get; set; }
            public string region { get; set; }
            public string country { get; set; }
            public float lat { get; set; }
            public float lon { get; set; }
            public string tz_id { get; set; }
            public float localtime_epoch { get; set; }
            public string localtime { get; set; }
        }

        public static WeatherInfo GetWeatherInfoAsync(string location)
        {
            string apiKey = "47e8a86a55b44efba93135029231803";
            string apiUrl = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={location}&aqi=no";
            
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString($"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={location}&aqi=no");
                return JsonConvert.DeserializeObject<WeatherInfo>(json);
            }
            
            /*using (var httpClient = new  System.Net.Http.HttpClient())
            {
                var response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<WeatherInfo>(json);
                }

                return null;
            }*/
        }
        
    }
