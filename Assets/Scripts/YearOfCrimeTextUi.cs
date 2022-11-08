using TMPro;
using UnityEngine;

/// <summary>
/// Responsible for capturing year data from the slider and updating
/// it's corresponding Ui text accordingly.
/// </summary>
public class YearOfCrimeTextUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI yearSliderText;

    public void UpdateSliderOutput(float sliderValue) // slider event
    {
        yearSliderText.text = "Year: " + sliderValue;
    }
}
