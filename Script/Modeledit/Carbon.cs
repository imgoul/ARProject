using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carbon : MonoBehaviour {

	
    public GameObject carbon1;
    public GameObject carbon2;
    public GameObject carbon3;
    public GameObject Atom_project;
    public Text text;
    public static GameObject basicatom;
    public static GameObject atom;
    public static List<GameObject> list = new List<GameObject>();
    public Button button;
    
    // Update is called once per frame
    void Update()
    {
        text.text = ButtonEvent.AtomName;
        if(GameObject.FindGameObjectWithTag("AtomProject") == null|| GameObject.FindGameObjectWithTag("AtomProject").transform.childCount == 0)
        {
            button.interactable = true;
            Destroy(GameObject.FindGameObjectWithTag("AtomProject"));
        }
     
    }

    public void Instancecarbon1()
    {
        basicatom = carbon1;
    }
    public void Instancecarbon2()
    {
        basicatom = carbon2;
    }
    public void Instancecarbon3()
    {
        basicatom = carbon3;
    }

    public void IsClone()
    {

        if(basicatom != null)
        {
            if(GameObject.FindGameObjectWithTag("AtomProject")==null)
            {
                atom = Instantiate(Atom_project);
                atom.transform.position = Vector3.zero;
                GameObject carbongo = Instantiate(basicatom);
                carbongo.transform.position = Vector3.zero;
                carbongo.transform.SetParent(atom.transform);
                button.interactable = false;
                list.Add(carbongo);
            }
        }
    }

    public void Delete()
    {
        if(atom!=null)
        {
            button.interactable = true;
            UiManager.Issave = false;
            dotmeshlink.stick = false;
            Destroy(atom);
        }
    }


}
