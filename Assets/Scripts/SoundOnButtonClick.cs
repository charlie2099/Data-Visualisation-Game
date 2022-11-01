using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

public class SoundOnButtonClick : MonoBehaviour
{
    [SerializeField]
    AudioClip clip;
    private void Start()
    {
        if(this.GetComponent<Button>() != null && clip != null)
            this.GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    private void OnMouseDown()
    {
        if (!isPointerOverUiElement())
        {
            //Debug.Log("On mouse over");
            if (clip != null)
                PlaySound();
        }
    }

    public void PlaySound()
    {
        AudioSource AUDIO_SOURCE = GameObject.Find("Button Source").GetComponent<AudioSource>();
        AUDIO_SOURCE.PlayOneShot(clip);
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
