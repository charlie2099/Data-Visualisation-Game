using Scriptables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static DataReaders.CSVReader;

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
        public bool Is_Visualization_Active;
        //Canvas Controllers
        public Canvas Visualization_Canvas;
        public Canvas Game_Canvas;
        public Canvas Selection_Canvas;

        //Game Manager
        public GameManager Game_Manager;
        
        //Gradient Initilization
        Gradient gradient;
        GradientColorKey[] colorKey;
        GradientAlphaKey[] alphaKey;

        //CSV Reader
        //[SerializeField] private CSVReader _CsvReader_Pull;
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
            Is_Visualization_Active = false;

            //Gradiant Coloring
            gradient = new Gradient();

            colorKey = new GradientColorKey[2];
            colorKey[0].color = Color.green;
            colorKey[0].time = 0.0f;
            colorKey[1].color = Color.red;
            colorKey[1].time = 1.0f;

            alphaKey = new GradientAlphaKey[2];
            alphaKey[0].alpha = 0.85f;
            alphaKey[0].time = 0.0f;
            alphaKey[1].alpha = 0.85f;
            alphaKey[1].time = 1.0f;

            gradient.SetKeys(colorKey, alphaKey);

        }

        //Normalize data for gradient use <3
        public float Normalization(float val, float max)
        {
            if (val > max)
            {
                return 1;
            }
            else
            {
                return val / max;
            }
        } 
        private void DisplayCrimeDataOnCitySelect(City city)
        {
            if (CrimeType.CrimeTypeName == null)
            {
                Debug.LogWarning("Please select a crime category");
                StartCoroutine(Alert());
                return;
            }

            if (Is_Game_Active) //If we are playing the game.
            {
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
                            else if (Is_Visualization_Active)
                            {
                                // Get the Renderer component
                                var renderer = city.GetComponent<Renderer>();

                                //Using normalization get the gradient colour <3
                                renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalHomicides, 30)));
                            }
                            break;
                        case "Harrassment":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Harassments: <color=orange>{cityData.totalHarrassments}</color>");
                            if (Is_Game_Active)
                            {
                                Game_Manager.Player_Chooses_City_For_Game(cityData.totalHarrassments, cityData.name, "Harrassment", cityData.year.ToString());
                            }
                            else if (Is_Visualization_Active)
                            {
                                // Get the Renderer component
                                var renderer = city.GetComponent<Renderer>();

                                //Using normalization get the gradient colour <3
                                renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalHarrassments, 5000)));
                            }
                            break;
                        case "Kidnapping":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Kidnappings: <color=orange>{cityData.totalKidnappings}</color>");
                            if (Is_Game_Active)
                            {
                                Game_Manager.Player_Chooses_City_For_Game(cityData.totalKidnappings, cityData.name, "Kidnapping", cityData.year.ToString());
                            }
                            else if (Is_Visualization_Active)
                            {
                                // Get the Renderer component
                                var renderer = city.GetComponent<Renderer>();

                                //Using normalization get the gradient colour <3
                                renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalKidnappings, 120)));
                            }
                            break;
                        case "Robbery":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Robberies: <color=orange>{cityData.totalRobberies}</color>");
                            if (Is_Game_Active)
                            {
                                Game_Manager.Player_Chooses_City_For_Game(cityData.totalRobberies, cityData.name, "Robbery", cityData.year.ToString());
                            }
                            else if (Is_Visualization_Active)
                            {
                                var renderer = city.GetComponent<Renderer>();
                                renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalRobberies, 5000)));
                            }
                            break;
                        case "Burglary":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Domestic Burglaries: <color=orange>{cityData.totalDomesticBurglaries}</color>");
                            if (Is_Game_Active)
                            {
                                Game_Manager.Player_Chooses_City_For_Game(cityData.totalDomesticBurglaries, cityData.name, "Burglary", cityData.year.ToString());
                            }
                            else if (Is_Visualization_Active)
                            {
                                var renderer = city.GetComponent<Renderer>();
                                renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalDomesticBurglaries, 50000)));
                            }
                            break;
                        case "Shoplifting":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Shoplifting: <color=orange>{cityData.totalShoplifting}</color>");
                            if (Is_Game_Active)
                            {
                                Game_Manager.Player_Chooses_City_For_Game(cityData.totalShoplifting, cityData.name, "Shoplifting", cityData.year.ToString());
                            }
                            else if (Is_Visualization_Active)
                            {
                                var renderer = city.GetComponent<Renderer>();
                                renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalShoplifting, 15000)));
                            }
                            break;
                        case "Theft":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Theft offences: <color=orange>{cityData.totalTheft}</color>");
                            if (Is_Game_Active)
                            {
                                Game_Manager.Player_Chooses_City_For_Game(cityData.totalTheft, cityData.name, "Theft", cityData.year.ToString());
                            }
                            else if (Is_Visualization_Active)
                            {
                                var renderer = city.GetComponent<Renderer>();
                                renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalTheft, 200000)));
                            }
                            break;
                        case "Arson":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Arson offences: <color=orange>{cityData.totalArson}</color>");
                            if (Is_Game_Active)
                            {
                                Game_Manager.Player_Chooses_City_For_Game(cityData.totalArson, cityData.name, "Arson", cityData.year.ToString());
                            }
                            else if (Is_Visualization_Active)
                            {
                                var renderer = city.GetComponent<Renderer>();
                                renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalArson, 1600)));
                            }
                            break;
                        case "Criminal damage":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Criminal Damage offences: <color=orange>{cityData.totalCriminalDamageOffences}</color>");
                            if (Is_Game_Active)
                            {
                                Game_Manager.Player_Chooses_City_For_Game(cityData.totalCriminalDamageOffences, cityData.name, "Criminal Damage Offences", cityData.year.ToString());
                            }
                            else if (Is_Visualization_Active)
                            {
                                var renderer = city.GetComponent<Renderer>();
                                renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalCriminalDamageOffences, 30000)));
                            }
                            break;
                        case "Drug possession":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Drug Possession offences: <color=orange>{cityData.totalDrugOffences}</color>");
                            if (Is_Game_Active)
                            {
                                Game_Manager.Player_Chooses_City_For_Game(cityData.totalDrugOffences, cityData.name, "Drug Offences", cityData.year.ToString());
                            }
                            else if (Is_Visualization_Active)
                            {
                                var renderer = city.GetComponent<Renderer>();
                                renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalDrugOffences, 5000)));
                            }
                            break;
                        case "Weapon possession":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Weapon Possession offences: <color=orange>{cityData.totalWeaponPossession}</color>");
                            if (Is_Game_Active)
                            {
                                Game_Manager.Player_Chooses_City_For_Game(cityData.totalWeaponPossession, cityData.name, "Weapon Possession", cityData.year.ToString());
                            }
                            else if (Is_Visualization_Active)
                            {
                                var renderer = city.GetComponent<Renderer>();
                                renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalWeaponPossession, 5000)));
                            }
                            break;
                        case "Total offences":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Offences: <color=orange>{cityData.totalOffences}</color>");
                            if (Is_Game_Active)
                            {
                                Game_Manager.Player_Chooses_City_For_Game(cityData.totalOffences, cityData.name, "Total Offences", cityData.year.ToString());
                            }
                            else if (Is_Visualization_Active)
                            {
                                var renderer = city.GetComponent<Renderer>();
                                renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalOffences, 180000)));
                            }
                            break;
                    }
                }
            }
            else if (Is_Visualization_Active) //If we are coloring the map
            {
                foreach (var cityData in CSVReader.CrimeDataset.cityDataList.Where(ctx => ctx.year == CrimeYear.YearOfCrime))
                {
                    
                    // There is probably a cleaner way to do this...
                    switch (CrimeType.CrimeTypeName)
                    {
                        case "Homicide":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Homicides: <color=orange>{cityData.totalHomicides}</color>");
                            if (Is_Visualization_Active)
                            {
                                
                                var _All_Cities = GameObject.FindObjectsOfType(typeof(City));
                                Debug.Log(_All_Cities.Length);
                                for(int i = 0; i < _All_Cities.Length; i++)
                                {
                                    // Get the Renderer component
                                    var renderer = _All_Cities[i].GetComponent<Renderer>();

                                    if (_All_Cities[i].GetComponent<City>().cityData.cityName == cityData.name)
                                    {
                                        //Using normalization get the gradient colour <3
                                        renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalHomicides, 30)));

                                    }

                                }
                            }
                            break;
                        case "Harrassment":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Harassments: <color=orange>{cityData.totalHarrassments}</color>");
                            if (Is_Visualization_Active)
                            {

                                var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

                                for (int i = 0; i < _All_Cities.Length; i++)
                                {
                                    // Get the Renderer component
                                    var renderer = _All_Cities[i].GetComponent<Renderer>();

                                    if (_All_Cities[i].GetComponent<City>().cityData.cityName == cityData.name)
                                    {
                                        //Using normalization get the gradient colour <3
                                        renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalHarrassments, 1300)));
                                    }

                                }
                            }
                            break;
                        case "Kidnapping":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Kidnappings: <color=orange>{cityData.totalKidnappings}</color>");
                            if (Is_Visualization_Active)
                            {

                                var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

                                for (int i = 0; i < _All_Cities.Length; i++)
                                {
                                    // Get the Renderer component
                                    var renderer = _All_Cities[i].GetComponent<Renderer>();

                                    if (_All_Cities[i].GetComponent<City>().cityData.cityName == cityData.name)
                                    {
                                        //Using normalization get the gradient colour <3
                                        renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalKidnappings, 80)));
                                    }

                                }
                            }
                            break;
                        case "Robbery":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Robberies: <color=orange>{cityData.totalRobberies}</color>");
                            if (Is_Visualization_Active)
                            {

                                var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

                                for (int i = 0; i < _All_Cities.Length; i++)
                                {
                                    // Get the Renderer component
                                    var renderer = _All_Cities[i].GetComponent<Renderer>();

                                    if (_All_Cities[i].GetComponent<City>().cityData.cityName == cityData.name)
                                    {
                                        //Using normalization get the gradient colour <3
                                        renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalRobberies, 3000)));
                                    }

                                }
                            }
                            break;
                        case "Burglary":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Domestic Burglaries: <color=orange>{cityData.totalDomesticBurglaries}</color>");
                            if (Is_Visualization_Active)
                            {

                                var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

                                for (int i = 0; i < _All_Cities.Length; i++)
                                {
                                    // Get the Renderer component
                                    var renderer = _All_Cities[i].GetComponent<Renderer>();

                                    if (_All_Cities[i].GetComponent<City>().cityData.cityName == cityData.name)
                                    {
                                        //Using normalization get the gradient colour <3
                                        renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalDomesticBurglaries, 25000)));
                                    }

                                }
                            }
                            break;
                        case "Shoplifting":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Shoplifting: <color=orange>{cityData.totalShoplifting}</color>");
                            if (Is_Visualization_Active)
                            {

                                var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

                                for (int i = 0; i < _All_Cities.Length; i++)
                                {
                                    // Get the Renderer component
                                    var renderer = _All_Cities[i].GetComponent<Renderer>();

                                    if (_All_Cities[i].GetComponent<City>().cityData.cityName == cityData.name)
                                    {
                                        //Using normalization get the gradient colour <3
                                        renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalShoplifting, 12000)));
                                    }

                                }
                            }
                            break;
                        case "Theft":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Theft offences: <color=orange>{cityData.totalTheft}</color>");
                            if (Is_Visualization_Active)
                            {

                                var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

                                for (int i = 0; i < _All_Cities.Length; i++)
                                {
                                    // Get the Renderer component
                                    var renderer = _All_Cities[i].GetComponent<Renderer>();

                                    if (_All_Cities[i].GetComponent<City>().cityData.cityName == cityData.name)
                                    {
                                        //Using normalization get the gradient colour <3
                                        renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalTheft, 150000)));
                                    }

                                }
                            }
                            break;
                        case "Arson":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Arson offences: <color=orange>{cityData.totalArson}</color>");
                            if (Is_Visualization_Active)
                            {

                                var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

                                for (int i = 0; i < _All_Cities.Length; i++)
                                {
                                    // Get the Renderer component
                                    var renderer = _All_Cities[i].GetComponent<Renderer>();

                                    if (_All_Cities[i].GetComponent<City>().cityData.cityName == cityData.name)
                                    {
                                        //Using normalization get the gradient colour <3
                                        renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalArson, 1600)));
                                    }

                                }
                            }
                            break;
                        case "Criminal damage":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Criminal Damage offences: <color=orange>{cityData.totalCriminalDamageOffences}</color>");
                            if (Is_Visualization_Active)
                            {

                                var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

                                for (int i = 0; i < _All_Cities.Length; i++)
                                {
                                    // Get the Renderer component
                                    var renderer = _All_Cities[i].GetComponent<Renderer>();

                                    if (_All_Cities[i].GetComponent<City>().cityData.cityName == cityData.name)
                                    {
                                        //Using normalization get the gradient colour <3
                                        renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalCriminalDamageOffences, 30000)));
                                    }

                                }
                            }
                            break;
                        case "Drug possession":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Drug Possession offences: <color=orange>{cityData.totalDrugOffences}</color>");
                            if (Is_Visualization_Active)
                            {

                                var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

                                for (int i = 0; i < _All_Cities.Length; i++)
                                {
                                    // Get the Renderer component
                                    var renderer = _All_Cities[i].GetComponent<Renderer>();

                                    if (_All_Cities[i].GetComponent<City>().cityData.cityName == cityData.name)
                                    {
                                        //Using normalization get the gradient colour <3
                                        renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalDrugOffences, 5000)));
                                    }

                                }
                            }
                            break;
                        case "Weapon possession":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Weapon Possession offences: <color=orange>{cityData.totalWeaponPossession}</color>");
                            if (Is_Visualization_Active)
                            {

                                var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

                                for (int i = 0; i < _All_Cities.Length; i++)
                                {
                                    // Get the Renderer component
                                    var renderer = _All_Cities[i].GetComponent<Renderer>();

                                    if (_All_Cities[i].GetComponent<City>().cityData.cityName == cityData.name)
                                    {
                                        //Using normalization get the gradient colour <3
                                        renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalWeaponPossession, 1000)));
                                    }

                                }
                            }
                            break;
                        case "Total offences":
                            Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Offences: <color=orange>{cityData.totalOffences}</color>");
                            if (Is_Visualization_Active)
                            {

                                var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

                                for (int i = 0; i < _All_Cities.Length; i++)
                                {
                                    // Get the Renderer component
                                    var renderer = _All_Cities[i].GetComponent<Renderer>();

                                    if (_All_Cities[i].GetComponent<City>().cityData.cityName == cityData.name)
                                    {
                                        //Using normalization get the gradient colour <3
                                        renderer.material.SetColor("_Color", gradient.Evaluate(Normalization(cityData.totalOffences, 180000)));
                                    }

                                }
                            }
                            break;
                    }
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
            Is_Visualization_Active = false;
        }

        private void PressedWiewVisualizationButton()
        {
            //Canvas Settings
            Visualization_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            Game_Canvas.renderMode = RenderMode.WorldSpace;
            Selection_Canvas.renderMode = RenderMode.WorldSpace;
            Is_Game_Active = false;
            Is_Visualization_Active = true;
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
