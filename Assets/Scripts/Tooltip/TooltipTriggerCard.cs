using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTriggerCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string content;
    public string header;
    public LayerMask layerMask;
    private RaycastHit[] _raycastHits;
    private GameObject tempCardGameObject;
    private Card tempCard;
    

    public void OnPointerEnter(PointerEventData eventData){
        TooltipSystem.Show(content,header);
    }

    public void OnPointerExit(PointerEventData eventData){
        TooltipSystem.Hide();
    }

    public void display(string name, string description)
    {
        this.header = "Name:" + name;
        if (description != null)
        {
            this.content = "Description: " + description;
        }
        

    }
}
