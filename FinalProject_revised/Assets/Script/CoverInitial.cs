using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverInitial : MonoBehaviour
{
    public Transform covers;
    public float scale = 1;
    // Start is called before the first frame update
    void Start()
    {
        Transform c = Instantiate(covers.GetChild(MusicIndex.index));
        c.parent = transform;
        c.localPosition = Vector3.zero;
        c.localScale = new Vector3(1,1,1) * scale;
    }
}
