using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Exit : MonoBehaviour, IPointerClickHandler
{
    public AudioSource audio;
    public void OnPointerClick(PointerEventData e)
    {
        audio.Play();
        Application.Quit();
    }
}
