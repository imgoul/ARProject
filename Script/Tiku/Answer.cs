using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{

    private Button toggle;
    public static List<string> thisname = new List<string>();
    public static List<string> Parentname = new List<string>();
    void Start()
    {
        toggle = this.GetComponent<Button>();
        toggle.onClick.AddListener(delegate { Istoggle(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Istoggle()
    {
        thisname.Add(this.name);
        this.GetComponent<Image>().color = Color.cyan;
        GameObject Parent = this.transform.parent.gameObject;
        Parentname.Add( Parent.name);
        Button[] buttons= Parent.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        
    }
}
