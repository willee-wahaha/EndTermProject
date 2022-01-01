using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texttest : MonoBehaviour
{
    Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();

        t.text = MusicIndex.index.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = MusicIndex.index.ToString();
    }
}
