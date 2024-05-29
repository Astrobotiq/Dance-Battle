using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string content;
    public string header;

    /*public void Awake()
    {
        CardInfo cardInfo = gameObject.GetComponent<CardInfo>();
        header = cardInfo.CardName;
        content = cardInfo.description;
    }*/

    public void OnPointerEnter(PointerEventData eventData){
        TooltipSystem.Show(content,header);
    }

    public void OnPointerExit(PointerEventData eventData){
       TooltipSystem.Hide();
    }
}