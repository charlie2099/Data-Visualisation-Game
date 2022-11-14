using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Returns : MonoBehaviour
{
    [SerializeField] public Canvas GameCavas;
    [SerializeField] public Canvas SelectionCanvas;
    [SerializeField] public Canvas Visualization_Canvas;

    [SerializeField] public Button ReturnButton1;
    [SerializeField] public Button ReturnButton2;
    void Start()
    {
        var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

/*        for (int i = 0; i < _All_Cities.Length; i++)
        {
            float rnd = Random.Range(0f, 155f);
            var renderer = _All_Cities[i].GetComponent<Renderer>();
            renderer.material.SetColor("_Color", new Color(rnd, rnd, rnd, rnd));
        }*/
        ReturnButton1.onClick.AddListener(Change_Canvasses);
        ReturnButton2.onClick.AddListener(Change_Canvasses);
    }

    public void Change_Canvasses()
    {
/*        var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

        for (int i = 0; i < _All_Cities.Length; i++)
        {
            float rnd = Random.Range(0f, 155f);
            _All_Cities[i].GetComponent<Renderer>().material.SetColor("_Color", new Color(rnd, rnd, rnd, 155));
        }*/

        if (GameCavas.renderMode == RenderMode.ScreenSpaceCamera || GameCavas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            GameCavas.renderMode = RenderMode.WorldSpace;
            SelectionCanvas.renderMode = RenderMode.ScreenSpaceCamera;  
        }
        else if (Visualization_Canvas.renderMode == RenderMode.ScreenSpaceCamera || Visualization_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            Visualization_Canvas.renderMode = RenderMode.WorldSpace;
            SelectionCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        }
    }
}
