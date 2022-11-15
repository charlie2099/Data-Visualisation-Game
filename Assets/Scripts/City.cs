using Scriptables;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class City : MonoBehaviour
{
    [SerializeField]
    //int cityAqi;
    public CityData Data => cityData;

    public String name;

    [SerializeField] public CityData cityData;
    private Material _material;

    private void Update()
    {
/*        int i = 0;
        if (i == 0)
        {
            Debug.Log(this.cityData.cityName);
            i++;
        }*/

        //Fix for gradient colour allocation
        name = this.cityData.cityName;
        this.name = this.cityData.cityName;
    }
    private void Awake() => _material = GetComponent<MeshRenderer>().material;



    [SerializeField] public String About_City_Data;
    [SerializeField] public TMP_Text City_Special_Data_Text;

    //Turn Related 
    [SerializeField]
    private TurnSystem turn_system;
    public void OnMouseDown()
    {
        Debug.Log("OBJECT NAME : " + this.gameObject.name);
        if (isPointerOverUiElement())
        {
            City_Special_Data_Text.text = "A Fact About " + this.gameObject.name + " : " + About_City_Data;
        }
    }
    private bool isPointerOverUiElement()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }


}
