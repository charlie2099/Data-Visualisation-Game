using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DataReaders
{
    public class CSVRequester : MonoBehaviour
    {
        private void OnEnable() => CitySelector.OnCitySelected += DisplayCrimeDataOnCitySelect;
        private void OnDisable() => CitySelector.OnCitySelected -= DisplayCrimeDataOnCitySelect;

        //Activates - Deavtives Game
        [SerializeField] public Button Activate_Game_Button;
        [SerializeField] public Button Activate_Visualization_Button;

        //Determines if the game loop is active, if not only pull data and show it in gradient.
        public bool Is_Game_Active;

        //Canvas Controllers
        public Canvas Visualization_Canvas;
        public Canvas Game_Canvas;
        public Canvas Selection_Canvas;

        //Game Manager
        public GameManager Game_Manager;

        //Alert
        [SerializeField] public Canvas AlertCanvas;
        private void Start()
        {

            //Canvas startup
            Visualization_Canvas.renderMode = RenderMode.WorldSpace;
            Game_Canvas.renderMode = RenderMode.WorldSpace;
            Selection_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            //Button Alocations
            Activate_Game_Button.onClick.AddListener(PressedPlayGameButton);
            Activate_Visualization_Button.onClick.AddListener(PressedWiewVisualizationButton);

            //Activation of the game is false at the start
            Is_Game_Active = false;

        }
        private void DisplayCrimeDataOnCitySelect(City city)
        {
            if (CrimeType.CrimeTypeName == null)
            {
                Debug.LogWarning("Please select a crime category");
                StartCoroutine(Alert());
                return;
            }



            foreach (var cityData in CSVReader.CrimeDataset.cityDataList.Where(ctx => ctx.year == CrimeYear.YearOfCrime).Where(ctx => ctx.name == city.Data.cityName))
            {
                // There is probably a cleaner way to do this...
                switch (CrimeType.CrimeTypeName)
                {
                    case "Homicide":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Homicides: <color=orange>{cityData.totalHomicides}</color>");
                        if (Is_Game_Active)
                        {
                            Game_Manager.Player_Chooses_City_For_Game(cityData.totalHomicides, cityData.name, "Homicides", cityData.year.ToString());
                        }
                        break;
                    case "Harrassment":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Harassments: <color=orange>{cityData.totalHarrassments}</color>");
                        if (Is_Game_Active)
                        {
                            Game_Manager.Player_Chooses_City_For_Game(cityData.totalHarrassments, cityData.name, "Harrassment", cityData.year.ToString());
                        }
                        break;
                    case "Kidnapping":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Kidnappings: <color=orange>{cityData.totalKidnappings}</color>");
                        if (Is_Game_Active)
                        {
                            Game_Manager.Player_Chooses_City_For_Game(cityData.totalKidnappings, cityData.name, "Kidnapping", cityData.year.ToString());
                        }
                        break;
                    case "Robbery":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Robberies: <color=orange>{cityData.totalRobberies}</color>");
                        if (Is_Game_Active)
                        {
                            Game_Manager.Player_Chooses_City_For_Game(cityData.totalRobberies, cityData.name, "Robbery", cityData.year.ToString());
                        }
                        break;
                    case "Burglary":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Domestic Burglaries: <color=orange>{cityData.totalDomesticBurglaries}</color>");
                        if (Is_Game_Active)
                        {
                            Game_Manager.Player_Chooses_City_For_Game(cityData.totalDomesticBurglaries, cityData.name, "Burglary", cityData.year.ToString());
                        }
                        break;
                    case "Shoplifting":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Shoplifting: <color=orange>{cityData.totalShoplifting}</color>");
                        if (Is_Game_Active)
                        {
                            Game_Manager.Player_Chooses_City_For_Game(cityData.totalShoplifting, cityData.name, "Shoplifting", cityData.year.ToString());
                        }
                        break;
                    case "Theft":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Theft offences: <color=orange>{cityData.totalTheft}</color>");
                        if (Is_Game_Active)
                        {
                            Game_Manager.Player_Chooses_City_For_Game(cityData.totalTheft, cityData.name, "Theft", cityData.year.ToString());
                        }
                        break;
                    case "Arson":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Arson offences: <color=orange>{cityData.totalArson}</color>");
                        if (Is_Game_Active)
                        {
                            Game_Manager.Player_Chooses_City_For_Game(cityData.totalArson, cityData.name, "Arson", cityData.year.ToString());
                        }
                        break;
                    case "Criminal damage":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Criminal Damage offences: <color=orange>{cityData.totalCriminalDamageOffences}</color>");
                        if (Is_Game_Active)
                        {
                            Game_Manager.Player_Chooses_City_For_Game(cityData.totalCriminalDamageOffences, cityData.name, "Criminal Damage Offences", cityData.year.ToString());
                        }
                        break;
                    case "Drug possession":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Drug Possession offences: <color=orange>{cityData.totalDrugOffences}</color>");
                        if (Is_Game_Active)
                        {
                            Game_Manager.Player_Chooses_City_For_Game(cityData.totalDrugOffences, cityData.name, "Drug Offences", cityData.year.ToString());
                        }
                        break;
                    case "Weapon possession":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Weapon Possession offences: <color=orange>{cityData.totalWeaponPossession}</color>");
                        if (Is_Game_Active)
                        {
                            Game_Manager.Player_Chooses_City_For_Game(cityData.totalWeaponPossession, cityData.name, "Weapon Possession", cityData.year.ToString());
                        }
                        break;
                    case "Total offences":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Offences: <color=orange>{cityData.totalOffences}</color>");
                        if (Is_Game_Active)
                        {
                            Game_Manager.Player_Chooses_City_For_Game(cityData.totalOffences, cityData.name, "Total Offences", cityData.year.ToString());
                        }
                        break;
                }
            }
        }

        // Enter a CrimeType (Key) to return a string (Value)
        private Dictionary<CrimeType, string> _crimeTypeDictionary;


        private void PressedPlayGameButton()
        {
            //Canvas Settings
            Visualization_Canvas.renderMode = RenderMode.WorldSpace;
            Game_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            Selection_Canvas.renderMode = RenderMode.WorldSpace;

            //Actiavte Game Settings
            Is_Game_Active = true;
        }

        private void PressedWiewVisualizationButton()
        {
            //Canvas Settings
            Visualization_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            Game_Canvas.renderMode = RenderMode.WorldSpace;
            Selection_Canvas.renderMode = RenderMode.WorldSpace;
            Is_Game_Active = false;
        }
    
         IEnumerator Alert()
        {
            if (Is_Game_Active)
            {
                AlertCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
                yield return new WaitForSeconds(2f);
                AlertCanvas.renderMode = RenderMode.WorldSpace;
            }
            yield return new WaitForSeconds(0.1f);
        }   
    }




}
