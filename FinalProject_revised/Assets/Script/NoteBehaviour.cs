using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MusicSheet.sheetGo) transform.localPosition -= new Vector3(0, 0, MusicSheet.speed*Time.deltaTime);
    }
}
