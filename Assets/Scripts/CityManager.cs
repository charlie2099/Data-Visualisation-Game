using System;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    [SerializeField]
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
