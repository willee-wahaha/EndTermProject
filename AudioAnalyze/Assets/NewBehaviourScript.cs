using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float[] spectrumData = new float[8192];
    public AudioSource audio;
    public Transform t, c;
    public float time = 0, timecount = 0;
    float lastdb = 0, lastdb2 = 0, db = 0, db2 = 0;
    public string file = @"E:\Unity\EndTermProject\sheet\m0.txt";
    FileInfo fileInfo;


    // Start is called before the first frame update
    void Start()
    {
        fileInfo = new FileInfo(file);
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
        float maxdb = 0;
        time += Time.deltaTime;
        timecount += Time.deltaTime;
        audio.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);
        float Tempdb = 0, Tempdb2 = 0;
        for (int i = 0; i < 8192; i++)
        {
            Transform n = transform.GetChild(i);
            n.localPosition = new Vector3(i * 0.01f, spectrumData[i]*100, 0);
            
            if (i < 500)
            {
                Tempdb += spectrumData[i];
            }
            else if(i < 5000)
            {
                Tempdb2 += spectrumData[i];
            }

            if (spectrumData[i] > maxdb) maxdb = spectrumData[i];
        }

        Debug.Log(maxdb);
        if (Tempdb > db) db = Tempdb;
        if (Tempdb2 > db2) db2 = Tempdb2;

        if (timecount >= 0.1)
        {
            StreamWriter sw = fileInfo.AppendText();

            if (((db - lastdb) / (lastdb + 0.001) >= 0.25 && maxdb >= 0.02) ||¡@maxdb >= 1.5)
            {
                
                sw.Write(time + "f, ");
                Transform n = Instantiate(c);
                n.parent = transform;
                n.localPosition = new Vector3(time, -10, 0);
            }

            if (((db2 - lastdb2) / (lastdb2 + 0.001) >= 0.25 && maxdb >= 0.02) || maxdb >= 1.5)
            {
                sw.Write(time + "f, ");
                Transform n = Instantiate(c);
                n.parent = transform;
                n.localPosition = new Vector3(time, -20, 0);
            }

            sw.Flush();
            sw.Close();

            lastdb = db;
            db = 0;

            lastdb2 = db2;
            db2 = 0;
            timecount = 0;
        }
        
        
    }

}
