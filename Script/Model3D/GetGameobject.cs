using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGameobject : MonoBehaviour {

    // Use this for initialization
    public static GameObject Atomprefab;
	
	// Update is called once per frame
	void Update () {
        Atomprefab = GameObject.FindGameObjectWithTag("Ting");
	}
}
