using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateShow : MonoBehaviour
{

    public Transform state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MusicSheet.iscomb)
        {
            if (transform.childCount != 0)
            {
                Destroy(transform.GetChild(0).gameObject);
            }

            Transform s = Instantiate(state.GetChild(1));
            s.parent = transform;
            s.localPosition = Vector3.zero;
        }
        else if (MusicSheet.ismiss)
        {
            if (transform.childCount != 0)
            {
                Destroy(transform.GetChild(0).gameObject);
            }

            Transform s = Instantiate(state.GetChild(0));
            s.SetParent(transform);
            s.localPosition = Vector3.zero;
        }
        else
        {
            if (transform.childCount != 0)
            {
                Destroy(transform.GetChild(0).gameObject);
            }
        }
    }
}
