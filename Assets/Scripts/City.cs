using Scriptables;
using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField]
    int cityAqi;
    public CityData Data => cityData; 
    
    [SerializeField] private CityData cityData;
    private Material _material;

    private void Awake() => _material = GetComponent<MeshRenderer>().material;

    public void SetCityColourBasedOnAqi(int cityAqi)
    {
        this.cityAqi = cityAqi; 
        _material.color = Color.Lerp(Color.green, Color.red, cityAqi*2.5f/300.0f);
    }




    //Turn Related 
    [SerializeField]
    private TurnSystem turn_system;
    public void OnMouseDown()
    {
        arrange_Turn_System();
        //invoke_GUESSING_GAME();
    }

    public void arrange_Turn_System()
    {
        this.turn_system = GameObject.Find("Turn Manager").GetComponent<TurnSystem>();
    }

    public void invoke_GUESSING_GAME()
    {
    
        if(this.turn_system != null)
        {
            if (turn_system.currently_busy == false)
            {
                if (turn_system.current_turn % 2 == 0)
                {

                    turn_system.p1_active = true;

                }
                else if (turn_system.current_turn % 2 == 1)
                {

                    turn_system.p2_active = true;

                }


                turn_system.instantiate_SLIDER_POP_UP();
                turn_system.p1_selecting = true;
                turn_system.choosen_states_air_quality = this.cityAqi;

                Debug.Log("Choosen State's Air Quality: " + turn_system.choosen_states_air_quality);
            }
        }
    }
}
