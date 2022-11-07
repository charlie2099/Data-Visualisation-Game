using System;
using System.Collections.Generic;
using DataReaders;
using UnityEngine;

/// <summary>
/// Stores a Dictionary of each city with it's corresponding API Url. 
/// Responsible for receiving API data from the requester to update
/// the colour of the city based on it's AQI.  
/// </summary>
public class CityManager : MonoBehaviour
{
    public static Dictionary<City, string> CityDictionary = new();

    private void OnEnable() => APIDataRequester.OnDataReceived += UpdateCityColour;
    private void OnDisable() => APIDataRequester.OnDataReceived -= UpdateCityColour;

    private void Start()
    {
        foreach (var city in FindObjectsOfType<City>())
        {
            CityDictionary.Add(city, city.Data.apiUrlReference);
        }
    }
    
    private void UpdateCityColour(City city, string cityName, int aqi)
    {
        city.SetCityColourBasedOnAqi(aqi);

        //Start the guessing name after pulling air quality data.
        city.invoke_GUESSING_GAME();
    }
}
