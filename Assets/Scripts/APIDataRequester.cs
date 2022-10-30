using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class APIDataRequester : MonoBehaviour
{
    public static event Action<string, int> OnDataReceived;
    [SerializeField] private string apiKey;

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

    private void OnEnable() => CitySelector.Instance.OnCitySelected += GetNewRequest;
    private void OnDisable() => CitySelector.Instance.OnCitySelected -= GetNewRequest;

    public void GetNewRequest(City city) 
    {
        StartCoroutine(GetRequest("https://api.waqi.info/feed/" + CityManager.Instance.CityDictionary[city] + "/?token=" + apiKey)); // 64e0d4bdf07eb3cfcc274a5a90d7f7ba7800565f
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
                    //Debug.Log("City: <color=red>" + coord.data.city.name + "</color>");
                    //Debug.Log("Time: <color=red>" + coord.data.time.s + "</color>");
                    //Debug.Log("Air Quality Index: <color=red>" + coord.data.aqi + "</color>");
                    OnDataReceived?.Invoke(coord.data.city.name, coord.data.aqi);
                    break;
            }
        }
    }
}
