using System.Linq;
using Testing;
using TMPro;
using UnityEngine;

public class SliderReader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI yearSliderText;
    private int _selectedYear;
    
    public void UpdateSliderOutput(float sliderValue)
    {
        yearSliderText.text = "Year: " + sliderValue;
        _selectedYear = (int)sliderValue;
    }

    public void SelectCrimeCategory()
    {
        const string CITYNAME = "Wiltshire";
        foreach (var cityData in CSVReader.CrimeDataset.cityDataList.Where(ctx => ctx.year == _selectedYear).Where(ctx => ctx.name == CITYNAME))
        {
            Debug.Log($"From year: {cityData.year}, City Name: {cityData.name}, Total Domestic Burglaries: {cityData.totalDomesticBurglaries}");
        }
    }
}
