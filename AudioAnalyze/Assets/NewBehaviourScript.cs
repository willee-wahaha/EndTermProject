using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float[] spectrumData = new float[8192];
    public AudioSource audio;
    public Transform t;
    public float time = 0, timecount = 0;
    float lastdb = 0, db = 0;
    public string name = "m0";
    FileInfo fileInfo;


    // Start is called before the first frame update
    void Start()
    {
        fileInfo = new FileInfo(@"E:\Unity\EndTermProject\sheet\"+ name +".txt");
        StreamWriter sw = fileInfo.CreateText();
        sw.WriteLine();
        sw.Flush();
        sw.Close();

        audio.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);
        for(int i=0; i<8192; i++)
        {
            Transform n = Instantiate(t);
            n.parent = transform;
            n.localPosition = new Vector3(i*0.01f,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timecount += Time.deltaTime;
        audio.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);
        float Tempdb = 0;
        for (int i = 0; i < 8192; i++)
        {
            Transform n = transform.GetChild(i);
            n.localPosition = new Vector3(i * 0.01f, spectrumData[i]*100, 0);

            if (i < 250)
            {
                Tempdb += spectrumData[i];
            }
        }

        Debug.Log(Tempdb);
        if (Tempdb > db) db = Tempdb;

        if (timecount >= 0.1)
        {
            if ((db - lastdb) / db >= 0.1 && db >= 0.02)
            {
                StreamWriter sw = fileInfo.AppendText();
                sw.Write(time + "f, ");
                sw.Flush();
                sw.Close();
            }

            lastdb = db;
            db = 0;
            timecount = 0;
        }
        
        
    }

}
