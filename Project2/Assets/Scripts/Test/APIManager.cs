using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Test
{
    public class APIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI cityNameText;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI airQualityIndexText;
        private string _apiKey;
        private string _city;

        public class City
        {
            public string name { get; set; }
            public string url { get; set; }
            public List<string> geo { get; set; }
        }
        
        public class Time
        {
            public string s { get; set; }
        }

        public class Data
        {
            public int aqi { get; set; }
            public Time time { get; set; }
            public City city { get; set; }
            public AirQualityIndex airQualityIndex { get; set; }
        }

        public class AirQualityIndex
        {
            public string pm25 { get; set; } // Pollutant
        }

        public class Root
        {
            public string status { get; set; }
            public Data data { get; set; }
        }
        
        /*public class Data
        {
            public int aqi { get; set; } // air quality index
            public double o3 { get; set; } // concentration of surface 03
            public double so2 { get; set; } // concentration of surface SO2 
            public double no2 { get; set; } // concentration of surface NO2
            public double co { get; set; } // concentration of carbon monoxide
            public int pm10 { get; set; } // concentration of particulate matter < 10 microns
            public int pm25 { get; set; } // concentration of particulate matter < 2.5 microns
            public int pollen_level_tree { get; set; } // tree pollen level (0 = None, 1 = Low, 2 = Moderate, 3 = High, 4 = Very High)
            public int pollen_level_grass { get; set; } // grass pollen level (0 = None, 1 = Low, 2 = Moderate, 3 = High, 4 = Very High)
            public int pollen_level_weed { get; set; } // weed pollen level (0 = None, 1 = Low, 2 = Moderate, 3 = High, 4 = Very High)
            public int mold_level { get; set; } // mold level (0 = None, 1 = Low, 2 = Moderate, 3 = High, 4 = Very High)
            public string predominant_pollen_type { get; set; } // predominant pollen type (Trees/Weeds/Molds/Grasses)
        }

        public class Root
        {
            public double lat { get; set; } // latitude 
            public double lon { get; set; } // longitude
            public string timezone { get; set; } 
            public string city_name { get; set; }
            public string country_code { get; set; } 
            public string state_code { get; set; }
            public Data data { get; set; }
        }*/

        public void SetApiKey(string key) => _apiKey = key; // Called via a click event on API Key InputField

        public void SetCity(string city) => _city = city; // Called via a click event on City InputField

        public void GetNewRequest() // Called via a click event on request button
        {
            StartCoroutine(GetRequest("https://api.waqi.info/feed/" + _city + "/?token=" + _apiKey)); // 64e0d4bdf07eb3cfcc274a5a90d7f7ba7800565f
            //StartCoroutine(GetRequest("https://api.weatherbit.io/v2.0/current/airquality?lat=35.7721&lon=-78.63861&key=" + apiKey));
        }

        private IEnumerator GetRequest(string url)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                yield return webRequest.SendWebRequest();

                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError(string.Format("Something went wrong: {0}", webRequest.error));
                        break;
                    case UnityWebRequest.Result.Success:
                        /*Fact fact = JsonConvert.DeserializeObject<Fact>(webRequest.downloadHandler.text);
                        Debug.Log("Fact: " + fact.fact);*/

                        Root coord = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                        cityNameText.text = "City: <color=red>" + coord.data.city.name + "</color>";
                        timeText.text = "Time: <color=red>" + coord.data.time.s + "</color>";
                        airQualityIndexText.text = "Air Quality Index: <color=red>" + coord.data.aqi + "</color>";
                        //Debug.Log("City: " + coord.data.city.name);
                        //Debug.Log("Time: " + coord.data.time.s);
                        //Debug.Log("Air Quality Index: " + coord.data.aqi);
                        //Debug.Log("Pollutant: " + coord.data.airQualityIndex.pm25);
                        //Debug.Log("Status: " + coord.status);

                        /*Root root = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                        Debug.Log("City Name: " + root.city_name);
                        Debug.Log("Country Code: " + root.country_code);
                        Debug.Log("State Code: " + root.state_code);
                        Debug.Log("Timezone: " + root.timezone);
                        Debug.Log("Latitude: " + root.lat);
                        Debug.Log("Longitude: " + root.lon);
                        Debug.Log("Air Quality Index: " + root.data.aqi);
                        Debug.Log("Concentration of surface O3:  " + root.data.o3);
                        Debug.Log("Concentration of surface SO2: " + root.data.so2);
                        Debug.Log("Concentration of surface NO2: " + root.data.no2);
                        Debug.Log("Concentration of carbon monoxide: " + root.data.co);
                        Debug.Log("Concentration of particulate matter < 2.5 microns: " + root.data.pm10);
                        Debug.Log("Concentration of particulate matter < 10 microns: " + root.data.pm25);
                        Debug.Log("Tree pollen level: " + root.data.pollen_level_tree);
                        Debug.Log("Grass pollen level : " + root.data.pollen_level_grass);
                        Debug.Log("Weed pollen level : " + root.data.pollen_level_weed);
                        Debug.Log("Mold level: " + root.data.mold_level);
                        Debug.Log("Predominant pollen type: " + root.data.predominant_pollen_type);*/
                        break;
                }
            }
        }
    }
}
