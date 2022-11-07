using UnityEngine;

public class CrimeType : MonoBehaviour
{
    public static string CrimeTypeName { get; private set; }
    
    public void SetCrimeTypeName(string crimeType) 
    {
        CrimeTypeName = crimeType;
        Debug.Log($"Crime: <color=orange>{CrimeTypeName}</color>");
    }
}
