using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCtrl : MonoBehaviour
{
    public int s = 0;
    private AudioSource audio;

    private void Awake()
    {
        Transform select = transform.GetChild(s);
        audio = select.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
