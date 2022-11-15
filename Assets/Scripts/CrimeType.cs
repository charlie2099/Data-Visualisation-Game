using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrimeType : MonoBehaviour
{
    public static string CrimeTypeName { get; set; }
    public static string CrimeTypeNameDisplay { get; set; }

    private void Start(){} 
    
    public void SetCrimeTypeName(string crimeType){
        CrimeTypeName = crimeType;
    }

    public void SetCrimeTypeNameDisplay(string crimeType){
        CrimeTypeNameDisplay = crimeType;
    }
}
