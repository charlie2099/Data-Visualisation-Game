using UnityEngine;

namespace Testing
{
    public class CubeColourLerper : MonoBehaviour
    {
        [Range(0, 300)] [SerializeField] private int aqi;
        private Material _material;

        private void Awake() => _material = GetComponent<MeshRenderer>().material;

        private void Update()
        {
            _material.color = Color.Lerp(Color.green, Color.red, aqi/300.0f);
        }
    }
}
