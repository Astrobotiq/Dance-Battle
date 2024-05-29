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
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _raycastHits = Physics.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, layerMask);
        if (_raycastHits.Length > 0)
        {
            tempCardGameObject = _raycastHits[0].transform.gameObject;
            tempCard = tempCardGameObject.GetComponent<Card>();
            content = tempCard.GetComponent<CardInfo>().description;
            header = tempCard.GetComponent<CardInfo>().CardName;
        }
    }

    public void OnPointerEnter(PointerEventData eventData){
        TooltipSystem.Show(content,header);
    }

    public void OnPointerExit(PointerEventData eventData){
        TooltipSystem.Hide();
    }
    
}
