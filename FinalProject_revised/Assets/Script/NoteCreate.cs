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
    // Start is called before the first frame update
    void Start()
    {
        float[] sheet = MusicSheet.musicSheet[MusicIndex.index];
        for(int i=0; i<sheet.Length; i++)
        {
            Transform n = Instantiate(note);
            n.parent = transform;
            n.localPosition = new Vector3(rnd.Next(-1, 2) * 0.1f, rnd.Next(-1, 2) * 0.1f, sheet[i] * MusicSheet.speed);
        }

        music = audio.GetChild(MusicIndex.index).GetComponent<AudioSource>();
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(music.isPlaying == false) SceneManager.LoadScene(3);
    }
}
