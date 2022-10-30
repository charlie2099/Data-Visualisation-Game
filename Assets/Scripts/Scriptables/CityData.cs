using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "CityData", menuName = "ScriptableObjects/CityData")]
    public class CityData : ScriptableObject
    {
        public string cityName;
        public string apiUrlReference;
        public GameObject landmarkModel;
    }
}
