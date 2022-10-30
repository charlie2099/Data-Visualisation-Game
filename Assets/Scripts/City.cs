using Scriptables;
using UnityEngine;

public class City : MonoBehaviour
{
    public CityData Data => cityData; 
    
    [SerializeField] private CityData cityData;
    private Material _material;

    private void Awake() => _material = GetComponent<MeshRenderer>().material;

    public void SetCityColourBasedOnAqi(int cityAqi)
    {
        _material.color = Color.Lerp(Color.green, Color.red, cityAqi*2.5f/300.0f);
    }
}
