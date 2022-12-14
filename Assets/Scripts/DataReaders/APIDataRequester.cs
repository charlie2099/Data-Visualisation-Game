using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace DataReaders
{
    /// <summary>
    /// Responsible for requesting data on a queried city from
    /// a given API endpoint. 
    /// </summary>
    public class APIDataRequester : MonoBehaviour
    {
        public static event Action<City, string, int> OnDataReceived;
        [SerializeField] private string apiKey;
        private City _requestedCity;

        public class Location // city
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
            public Location city { get; set; }
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

        private void OnEnable() => CitySelector.OnCitySelected += GetNewRequest;
        private void OnDisable() => CitySelector.OnCitySelected -= GetNewRequest;

        public void GetNewRequest(City city)
        {
            _requestedCity = city;
            StartCoroutine(GetRequest("https://api.waqi.info/feed/" + CityManager.CityDictionary[_requestedCity] + "/?token=" + apiKey)); // 64e0d4bdf07eb3cfcc274a5a90d7f7ba7800565f
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
                        Debug.LogError($"Something went wrong: {webRequest.error}");
                        break;
                    case UnityWebRequest.Result.Success:
                        Root root = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                        OnDataReceived?.Invoke(_requestedCity, root.data.city.name, root.data.aqi);
                        break;
                }
            }
        }
    }
}
