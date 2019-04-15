using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotmeshlink : MonoBehaviour
{

    public static bool stick = false;
    
    // Update is called once per frame
    void Update()
    {
        if(stick)
        {

        }
    }


    public void OnTriggerEnter(Collider other)
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "atom")
        {
            if (UiManager.Issave)
            {
                Destroy(this.gameObject);
                stick = true;
           }

        }
    }

}
