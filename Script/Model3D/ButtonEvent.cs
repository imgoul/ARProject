using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonEvent : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler
{

    // Use this for initialization
    public static string TypeName;
    public static bool isOnclick;
    public static string AtomName;
    void Start()
    {
        isOnclick = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TypeName = this.name;
        AtomName = this.name;
        isOnclick = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TypeName = this.name;
    }


}
