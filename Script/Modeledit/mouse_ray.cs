using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_ray : MonoBehaviour {

    // Use this for initialization
    public static GameObject selectgame;
	
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, 1000))
        {
            //Debug.DrawRay(Camera.main.transform.position,Input.mousePosition, Color.red);
            if (Input.GetMouseButtonDown(0))
            {
                if (raycastHit.collider.tag == "linkdot")
                {

                    if (Carbon.basicatom != null)
                    {

                        GameObject go = GameObject.Instantiate(Carbon.basicatom, raycastHit.collider.transform.position, raycastHit.collider.transform.rotation);
                        go.transform.SetParent(Carbon.atom.transform);
                        go.name = ButtonEvent.AtomName;

                        Carbon.list.Add(go);
                    }
                }

                if(raycastHit.collider.tag=="atom")
                {
                    selectgame = raycastHit.collider.gameObject;
                    
            
                }
            }
        }
    }
    
}
