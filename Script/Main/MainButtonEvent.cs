using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class MainButtonEvent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{

    public static string TypeId;
    public static bool isOnclick;
    void Start()
    {
        isOnclick = false;
    }
   
    public void OnPointerClick(PointerEventData eventData)
    {
        TypeId = this.name;
        isOnclick = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TypeId = this.name;
    }
}
