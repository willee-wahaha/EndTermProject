using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShow : MonoBehaviour
{
    Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();

        t.text = "Max Comb : " + MusicSheet.maxComb.ToString() + "\nHits : " + MusicSheet.hit.ToString() + "\nMiss : " + MusicSheet.miss.ToString();
    }
}
