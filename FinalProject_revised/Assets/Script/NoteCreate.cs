using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteCreate : MonoBehaviour
{
    public Transform note;
    public Transform audio;
    private AudioSource music;
    private System.Random rnd = new System.Random();
    private float CountDown = 3, timeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        MusicSheet.Reset();

        CountDown = 3;
        timeCount = 0;

        float[] sheet = MusicSheet.musicSheet[MusicIndex.index];
        for(int i=0; i<sheet.Length; i++)
        {
            Transform n = Instantiate(note);
            n.parent = transform;
            n.localPosition = new Vector3(rnd.Next(-1, 2) * 0.1f, -0.5f * 0.1f, sheet[i] * MusicSheet.speed);
        }

        music = audio.GetChild(MusicIndex.index).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MusicSheet.sheetGo) timeCount += Time.deltaTime;
        if(timeCount >= 1)
        {
            timeCount = 0;
            CountDown--;
            if(CountDown == 0)
            {
                MusicSheet.sheetGo = true;
                music.Play();
            }
        }
        if(music.isPlaying == false && MusicSheet.sheetGo)
        {
            timeCount += Time.deltaTime;
            if(timeCount >= 1)
            {
                timeCount = 0;
                CountDown++;
                if (CountDown == 3)
                {
                    MusicSheet.sheetGo = false;
                    SceneManager.LoadScene(3);
                }
            }
        }
    }
}
