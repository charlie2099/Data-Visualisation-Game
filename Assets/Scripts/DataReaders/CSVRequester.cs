using System;
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
            foreach (var cityData in CSVReader.CrimeDataset.cityDataList.Where(ctx => ctx.year == CrimeYear.YearOfCrime).Where(ctx => ctx.name == city.Data.cityName))
            {
                //Debug.Log($"From year: <color=orange>{cityData.year}</color>, City Name: <color=orange>{cityData.name}</color>, Total Domestic Burglaries: <color=orange>{cityData.totalDomesticBurglaries}</color>");
                Debug.Log($"From year: <color=orange>{cityData.year}</color>, City Name: <color=orange>{cityData.name}</color>, Total Domestic Burglaries: <color=orange>{cityData.totalDomesticBurglaries}</color>");
            }
        }
    }
}
