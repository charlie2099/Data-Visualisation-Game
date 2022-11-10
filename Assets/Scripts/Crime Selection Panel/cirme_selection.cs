using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cirme_selection : MonoBehaviour
{
    [SerializeField]
    [Header("Canvasses")]
    public Canvas gaming_canvas;
    public Canvas crime_selection_canvas;
    [Header("Crime Selection Buttons")]
    public Button Homicides_button;
    public Button Harassment_button;
    public Button Kidnapping_button;
    public Button Robberies_button;
    public Button Domestic_burglary_button;
    public Button Shoplifting_button;
    public Button Theft_button;
    public Button Arson_button;
    public Button Criminal_damage_button;
    public Button Drug_possession_button;
    public Button Weapon_possession_button;
    public Button ALL_CRIME;
    // Start is called before the first frame update
    void Start()
    {
        gaming_canvas.enabled = false;

        //DATA ALACOTAR LISTENERS ( PULL EQUIVELENT DATA FROM API)
        Homicides_button.onClick.AddListener(pull_homicide_data);
        Harassment_button.onClick.AddListener(pull_Harassment_data);
        Kidnapping_button.onClick.AddListener(pull_Kidnapping_data);
        Robberies_button.onClick.AddListener(pull_Robberies_data);
        Domestic_burglary_button.onClick.AddListener(pull_burglary_data);
        Shoplifting_button.onClick.AddListener(pull_Shoplifting_data);
        Theft_button.onClick.AddListener(pull_Theft_data);
        Arson_button.onClick.AddListener(pull_Arson_data);
        Criminal_damage_button.onClick.AddListener(pull_Criminal_damage_data);
        Drug_possession_button.onClick.AddListener(pull_Drug_possession_data);
        Weapon_possession_button.onClick.AddListener(pull_weapon_possession_data);
        ALL_CRIME.onClick.AddListener(pull_all_crime_data);

        //ON CLICK DEACTIVE THIS, ACTIVE THE GAME.
        //MUST BE AFTER DATA ALOCATOR LISTENERS
        Homicides_button.onClick.AddListener(deactive_selector_canvas_activate_gaming_canvas);
        Harassment_button.onClick.AddListener(deactive_selector_canvas_activate_gaming_canvas); ;
        Kidnapping_button.onClick.AddListener(deactive_selector_canvas_activate_gaming_canvas); ;
        Robberies_button.onClick.AddListener(deactive_selector_canvas_activate_gaming_canvas); ;
        Domestic_burglary_button.onClick.AddListener(deactive_selector_canvas_activate_gaming_canvas); ;
        Shoplifting_button.onClick.AddListener(deactive_selector_canvas_activate_gaming_canvas); ;
        Theft_button.onClick.AddListener(deactive_selector_canvas_activate_gaming_canvas); ;
        Arson_button.onClick.AddListener(deactive_selector_canvas_activate_gaming_canvas); ;
        Criminal_damage_button.onClick.AddListener(deactive_selector_canvas_activate_gaming_canvas); ;
        Drug_possession_button.onClick.AddListener(deactive_selector_canvas_activate_gaming_canvas); ;
        Weapon_possession_button.onClick.AddListener(deactive_selector_canvas_activate_gaming_canvas); ;
        ALL_CRIME.onClick.AddListener(deactive_selector_canvas_activate_gaming_canvas);
}
    //Homicide
    private void pull_homicide_data()
    {

    }
    //Harrasment
    private void pull_Harassment_data()
    {

    }
    //Kidnaping
    private void pull_Kidnapping_data()
    {

    }
    //Robbery
    private void pull_Robberies_data()
    {

    }
    //Burglary
    private void pull_burglary_data()
    {

    }
    //Shoplifting
    private void pull_Shoplifting_data()
    {

    }
    //Theft
    private void pull_Theft_data()
    {

    }
    //Arson
    private void pull_Arson_data()
    {

    }

    //Criminal Damage
    private void pull_Criminal_damage_data()
    {

    }

    //Drug Possession
    private void pull_Drug_possession_data()
    {

    }

    //Weapon Possesion
    private void pull_weapon_possession_data()
    {

    }

    //ALL CRIME
    private void pull_all_crime_data()
    {

    }
    private void deactive_selector_canvas_activate_gaming_canvas()
    {
        crime_selection_canvas.enabled = false;
        gaming_canvas.enabled = true;
    }
}
