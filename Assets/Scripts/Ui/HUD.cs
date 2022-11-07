using DataReaders;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cityNameText;
    [SerializeField] private TextMeshProUGUI cityAQIText;

    private void OnEnable() => APIDataRequester.OnDataReceived += UpdateUiOnAPIRequest;
    private void OnDisable() => APIDataRequester.OnDataReceived -= UpdateUiOnAPIRequest;

    private void UpdateUiOnAPIRequest(City city, string cityName, int cityAqi)
    {
        cityNameText.text = "City: <color=red>" + cityName + "</color>";
        cityAQIText.text = "City AQI: <color=red>" + cityAqi + "</color>";
    }
}
