using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CrimeType;
using static CrimeYear;



public class CrimeRandom : MonoBehaviour
{
    [SerializeField] public Slider mSlider;

    public void SetCrimeRandom(){
        var list = new List<string>{ "Theft","Burglary","Kidnapping","Homicide","Criminal damage","Drug possession","Weapon possession","Arson","Harrassment","Robbery","Shoplifting","Total offences"};
        var list2 = new List<string>{ "Theft","Burglary","Kidnapping","Homicides","Criminal Damage Offences","Drug Offences","Weapon Possession","Arson","Harrassment","Robbery","Shoplifting","Total Offences"};
        int random = Random.Range(0, list.Count);
        CrimeTypeName = list[random];
        CrimeTypeNameDisplay = list2[random];
        YearOfCrime = Random.Range(2002, 2015);
        mSlider.value = YearOfCrime;
    } 
}
