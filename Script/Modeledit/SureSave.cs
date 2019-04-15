using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SureSave : MonoBehaviour {
    
    // Update is called once per frame
    void Update()
    {
        if(UiManager.Issave&&dotmeshlink.stick)
        {
            if(this.transform.childCount==1|| this.transform.childCount>0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
