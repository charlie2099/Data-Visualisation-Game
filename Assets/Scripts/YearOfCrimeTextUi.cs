using TMPro;
using UnityEngine;

/// <summary>
/// Responsible for capturing year data from the slider and updating
/// it's corresponding Ui text accordingly.
/// </summary>
public class YearOfCrimeTextUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI yearSliderText;
    [SerializeField] private TextMeshProUGUI year2SliderText;
    public void UpdateSliderOutput(float sliderValue) // slider event
    {
        yearSliderText.text = "Year: " + sliderValue;
        year2SliderText.text = "Year: " + sliderValue;
    }
}
