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
        if (transform.parent.name != "NoteCreater") Destroy(transform.gameObject);

        if (MusicSheet.sheetGo) transform.localPosition -= new Vector3(0, 0, MusicSheet.speed*Time.deltaTime);

        if(transform.localPosition.z <= 0)
        {
            MusicSheet.comb = 0;
            MusicSheet.miss++;
            MusicSheet.iscomb = false;
            MusicSheet.ismiss = true;
            Destroy(transform.gameObject);
        }
    }
}
