using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCenter : MonoBehaviour
{

    // Use this for initialization
    public static Vector3 center;
    
    // Update is called once per frame
    void Update()
    {
        if(transform.childCount>0)
        {
            center = getcenter();
        }
       
        if(GetGameobject.Atomprefab!=null)
        {
            this.transform.position = new Vector3(1.9f, 0, 0);
        }
        else
        {
            this.transform.position = Vector3.zero;
        }
        
    }
    public Vector3 getcenter()
    {
        Vector3 postion = this.transform.position;

        Quaternion rotation = this.transform.rotation;

        Vector3 scale = this.transform.localScale;

        this.transform.position = Vector3.zero;

        this.transform.rotation = Quaternion.Euler(Vector3.zero);

        this.transform.localScale = Vector3.one;

        Vector3 center = Vector3.zero;
        Renderer[] renderers = this.GetComponentsInChildren<Renderer>();

        foreach (var child in renderers)
        {
            center += child.bounds.center;
        }

        center /= this.GetComponentsInChildren<Renderer>().Length;
        Bounds bounds = new Bounds(center, Vector3.zero);

        foreach (var item in renderers)
        {
            bounds.Encapsulate(item.bounds);
        }

        this.transform.position = postion;
        this.transform.rotation = rotation;
        this.transform.localScale = scale;
        foreach (Transform item in this.transform)
        {
            item.position = item.position - bounds.center;
        }
        this.transform.position = bounds.center + this.transform.position;
        return this.transform.position;
    }
}
