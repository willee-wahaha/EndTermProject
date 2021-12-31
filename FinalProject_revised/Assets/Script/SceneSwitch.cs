using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour, IPointerClickHandler
{
    public AudioSource audio;
    public int index = 0;

    public void OnPointerClick(PointerEventData e)
    {
        audio.Play();
        
        SceneManager.LoadScene(index);
    }
}
