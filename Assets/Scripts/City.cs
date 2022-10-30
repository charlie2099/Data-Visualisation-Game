using System;
using System.Collections;
using System.Collections.Generic;
using Scriptables;
using UnityEngine;

public class City : MonoBehaviour
{
    public CityData Data => cityData; 
    
    [SerializeField] private CityData cityData;
}
