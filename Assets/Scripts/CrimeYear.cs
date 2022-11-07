using UnityEngine;

/// <summary>
/// Responsible for capturing data from the year slider and
/// storing it in a variable to be used later.
/// </summary>
public class CrimeYear : MonoBehaviour
{
    public static int YearOfCrime { get; private set; }

    public void SetCrimeYear(float year)
    {
        YearOfCrime = (int)year;
        Debug.Log($"Year: <color=orange>{YearOfCrime}</color>");
        // invoke event?
    }
}
