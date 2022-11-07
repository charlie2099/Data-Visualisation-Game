using System;
using System.Linq;
using Testing;
using TMPro;
using UnityEngine;

public class SliderReader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI yearSliderText;
    private int _selectedYear = 2002;
    private string _selectedCity;

    private void OnEnable() => CitySelector.OnCitySelected += UpdateSelectedCity;
    private void OnDisable() => CitySelector.OnCitySelected -= UpdateSelectedCity;

    public void UpdateSliderOutput(float sliderValue)
    {
        yearSliderText.text = "Year: " + sliderValue;
        _selectedYear = (int)sliderValue;
    }

    public void UpdateSelectedCity(City city)
    {
        _selectedCity = city.Data.cityName;
        
        foreach (var cityData in CSVReader.CrimeDataset.cityDataList.Where(ctx => ctx.year == _selectedYear).Where(ctx => ctx.name == _selectedCity))
        {
            Debug.Log($"From year: <color=orange>{cityData.year}</color>, City Name: <color=orange>{cityData.name}</color>, Total Domestic Burglaries: <color=orange>{cityData.totalDomesticBurglaries}</color>");
        }
    }

    public void SelectCrimeCategory()
    {
        foreach (var cityData in CSVReader.CrimeDataset.cityDataList.Where(ctx => ctx.year == _selectedYear).Where(ctx => ctx.name == _selectedCity))
        {
            Debug.Log($"From year: <color=orange>{cityData.year}</color>, City Name: <color=orange>{cityData.name}</color>, Total Domestic Burglaries: <color=orange>{cityData.totalDomesticBurglaries}</color>");
        }
    }
}
