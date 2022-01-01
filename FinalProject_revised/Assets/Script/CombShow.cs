using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombShow : MonoBehaviour
{
    Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();

        t.text = MusicSheet.comb.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = MusicSheet.comb.ToString();
    }
}
