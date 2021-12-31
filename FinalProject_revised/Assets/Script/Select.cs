using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Select : MonoBehaviour, IPointerClickHandler
{
    public AudioSource audio;
    public Transform frontCover;
    public Transform Covers;
    public bool isLeft = false;

    public void OnPointerClick(PointerEventData e)
    {
        audio.Play();

        
        if (isLeft)
        {
            MusicIndex.index--;
            if(MusicIndex.index < 0)
            {
                MusicIndex.index = MusicIndex.numOfMusic - 1;
            }
        }
        else
        {
            MusicIndex.index++;
            if(MusicIndex.index >= MusicIndex.numOfMusic)
            {
                MusicIndex.index = 0;
            }
        }

        Destroy(frontCover.GetChild(0).gameObject);
        Transform c = Instantiate(Covers.GetChild(MusicIndex.index));
        c.parent = frontCover;
        c.localPosition = Vector3.zero;
        c.localScale = new Vector3(1,1,1);
    }
}
