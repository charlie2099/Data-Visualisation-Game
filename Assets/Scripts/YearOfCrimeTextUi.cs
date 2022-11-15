using TMPro;
using UnityEngine;
using static CrimeType;

/// <summary>
/// Responsible for capturing year data from the slider and updating
/// it's corresponding Ui text accordingly.
/// </summary>
public class YearOfCrimeTextUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI yearSliderText;
    [SerializeField] private TextMeshProUGUI year2SliderText;
    [SerializeField] public TMP_Text Crime_Name_Holder;
    public void UpdateSliderOutput(float sliderValue) // slider event
    {
        yearSliderText.text = "Year: " + sliderValue;
        year2SliderText.text = "Year: " + sliderValue;

        //If is null, set to default when slide
        if(string.IsNullOrEmpty(CrimeTypeNameDisplay)){
            CrimeType.CrimeTypeName = "Theft";
            CrimeType.CrimeTypeNameDisplay = "Theft";
        }

        Crime_Name_Holder.text = CrimeTypeNameDisplay + " in " + sliderValue;
    }
}
