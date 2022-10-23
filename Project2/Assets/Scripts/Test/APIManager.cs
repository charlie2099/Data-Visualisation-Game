using System;
using System.Collections;
using Newtonsoft.Json;
using UnityEditor;
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
        
        private void Start()
        {
            StartCoroutine(GetRequest(urlToAPI)); // https://catfact.ninja/fact
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
                        Fact fact = JsonConvert.DeserializeObject<Fact>(webRequest.downloadHandler.text);
                        Debug.Log("Fact: " + fact.fact);
                        break;
                }
            }
        }



















        // API URL
        //public string url;
        
        // JSON Result from API request
        //public JSONNode jsonResult;

        /*private IEnumerator GetRequest(string location)
        {
            // Create the web request and download handler
            UnityWebRequest webRequest = new UnityWebRequest();
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            
            // Build the url and query
            webRequest.url = string.Format("{0}&q={1}", url, location);
            
            // Send the web request and wait for a returning result
            yield return webRequest.SendWebRequest();
            
            // Convert the byte array and wait for a returning result
            string rawJson = Encoding.Default.GetString(webRequest.downloadHandler.data);
            
            // Parse the raw string into a json result that is more readable
            //JSON.Parse(rawJson);
        }*/
    }
}
