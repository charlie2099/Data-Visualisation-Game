using System;
using UnityEngine;

public class CitySelector : MonoBehaviour
{
    public event Action<City> OnCitySelected;
    public static CitySelector Instance;
    public City SelectedCity => _selectedCity;
    
    [SerializeField] private Camera cam;
    private City _selectedCity;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hitInfo.transform.GetComponent<City>() != null)
                {
                    var city = hitInfo.transform.GetComponent<City>();
                    OnCitySelected?.Invoke(city);
                    _selectedCity = city;
                }
            }
        }
    }
}
