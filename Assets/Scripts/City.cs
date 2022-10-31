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



    private TurnSystem turn_system;
    public void OnMouseDown()
    {
        invoke_GUESSING_GAME();
    }
    public void invoke_GUESSING_GAME()
    {
        this.turn_system = GameObject.Find("Turn Manager").GetComponent<TurnSystem>();

        if (turn_system.currently_busy == false)
        {
            turn_system.instantiate_SLIDER_POP_UP();
            turn_system.p1_active = true;
        }
    }
}
