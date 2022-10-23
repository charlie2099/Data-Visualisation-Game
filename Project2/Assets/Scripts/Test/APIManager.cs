using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Test
{
    public class APIManager : MonoBehaviour
    {
        [SerializeField] private string urlToAPI; 
        
        public class Fact
        {
            public string fact { get; set; }
            public int length { get; set; }
        }

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



        private void Start()
        {
            StartCoroutine(GetRequest(urlToAPI)); // https://catfact.ninja/fact  // https://api.waqi.info/feed/here/?token=64e0d4bdf07eb3cfcc274a5a90d7f7ba7800565f
        }

        public void GetNewRequest() // Called via a click event on request button
        {
            Start();
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
                        //Fact fact = JsonConvert.DeserializeObject<Fact>(webRequest.downloadHandler.text);
                        //Debug.Log("Fact: " + fact.fact);

                        Root coord = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                        Debug.Log("City: " + coord.data.city.name);
                        Debug.Log("Time: " + coord.data.time.s);
                        Debug.Log("Air Quality Index: " + coord.data.aqi);
                        //Debug.Log("Pollutant: " + coord.data.airQualityIndex.pm25);
                        Debug.Log("Status: " + coord.status);

                        break;
                }
            }
        }
    }
}
