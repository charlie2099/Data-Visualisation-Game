using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DataReaders
{
    public class CSVRequester : MonoBehaviour
    {
        private void OnEnable() => CitySelector.OnCitySelected += DisplayCrimeDataOnCitySelect;
        private void OnDisable() => CitySelector.OnCitySelected -= DisplayCrimeDataOnCitySelect;

        private void DisplayCrimeDataOnCitySelect(City city)
        {
            if (CrimeType.CrimeTypeName == null)
            {
                Debug.LogWarning("Please select a crime category");
                return;
            }
            
            foreach (var cityData in CSVReader.CrimeDataset.cityDataList.Where(ctx => ctx.year == CrimeYear.YearOfCrime).Where(ctx => ctx.name == city.Data.cityName))
            {
                // There is probably a cleaner way to do this...
                switch (CrimeType.CrimeTypeName)
                {
                    case "Homicide":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Homicides: <color=orange>{cityData.totalHomicides}</color>");
                        break;
                    case "Harrassment":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Harassments: <color=orange>{cityData.totalHarrassments}</color>");
                        break;
                    case "Kidnapping":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Kidnappings: <color=orange>{cityData.totalKidnappings}</color>");
                        break;
                    case "Robbery":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Robberies: <color=orange>{cityData.totalRobberies}</color>");
                        break;
                    case "Burglary":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Domestic Burglaries: <color=orange>{cityData.totalDomesticBurglaries}</color>");
                        break;
                    case "Shoplifting":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Shoplifting: <color=orange>{cityData.totalShoplifting}</color>");
                        break;
                    case "Theft":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Theft offences: <color=orange>{cityData.totalTheft}</color>");
                        break;
                    case "Arson":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Arson offences: <color=orange>{cityData.totalArson}</color>");
                        break;
                    case "Criminal damage":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Criminal Damage offences: <color=orange>{cityData.totalCriminalDamageOffences}</color>");
                        break;
                    case "Drug possession":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Drug Possession offences: <color=orange>{cityData.totalDrugOffences}</color>");
                        break;
                    case "Weapon possession":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Weapon Possession offences: <color=orange>{cityData.totalWeaponPossession}</color>");
                        break;
                    case "Total offences":
                        Debug.Log($"From year: <color=orange>{cityData.year}</color>, County Name: <color=orange>{cityData.name}</color>, Total Offences: <color=orange>{cityData.totalOffences}</color>");
                        break;
                }
            }
        }

        // Enter a CrimeType (Key) to return a string (Value)
        private Dictionary<CrimeType, string> _crimeTypeDictionary;
    }
}
