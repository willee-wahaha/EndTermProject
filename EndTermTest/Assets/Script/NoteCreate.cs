using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NoteCreate : MonoBehaviour
{
    public Transform note;
    public int musicIndex = 0;

    private float timecount = 0;
    private int lenthOfSong, sec = 0;
    private System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        int[] sheet = SheetMusic.musicList[musicIndex];

        for(int i=0; i<sheet.Length; i+=3)
        {
            int time = sheet[i], x = sheet[i+1], y = sheet[i+2];


            Transform n = Instantiate(note);
            n.parent = transform;
            n.localPosition = new Vector3(x, y, time * 10);
        }


        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
