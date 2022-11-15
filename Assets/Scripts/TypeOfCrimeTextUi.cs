using TMPro;
using UnityEngine;
using static CrimeYear;
using static CrimeType;


/// <summary>
/// Responsible for capturing year data from the slider and updating
/// it's corresponding Ui text accordingly.
/// </summary>
public class TypeOfCrimeTextUi : MonoBehaviour
{
    [SerializeField] public TMP_Text Crime_Name_Holder;
    [SerializeField] public TMP_Text Crime_Name_Holder_Visualization;
    public void UpdateCrimeType() // slider event
    {
        Crime_Name_Holder.text = CrimeTypeNameDisplay + " in " + YearOfCrime;
    }

    public void UpdateCrimeTypeVisualization() // slider event
    {
        Crime_Name_Holder_Visualization.text = CrimeTypeNameDisplay;
        Crime_Name_Holder_Visualization.color = Color.white;
    }
}
