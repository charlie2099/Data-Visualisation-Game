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

        public void SetApiKey(string key) => _apiKey = key; // Called via a click event on API Key InputField

        public void SetCity(string city) => _city = city; // Called via a click event on City InputField

        public void GetNewRequest() // Called via a click event on request button
        {
            StartCoroutine(GetRequest("https://api.waqi.info/feed/" + _city + "/?token=" + _apiKey)); // 64e0d4bdf07eb3cfcc274a5a90d7f7ba7800565f
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
                        Root coord = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                        cityNameText.text = "City: <color=red>" + coord.data.city.name + "</color>";
                        timeText.text = "Time: <color=red>" + coord.data.time.s + "</color>";
                        airQualityIndexText.text = "Air Quality Index: <color=red>" + coord.data.aqi + "</color>";
                        break;
                }
            }
        }
    }
}
