using System;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    public static CityManager Instance;
    public Dictionary<City, string> CityDictionary = new Dictionary<City, string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        foreach (var city in FindObjectsOfType<City>())
        {
            //Debug.Log("City found: " + city.Data.cityName);
            CityDictionary.Add(city, city.Data.apiUrlReference);
        }
    }
}
