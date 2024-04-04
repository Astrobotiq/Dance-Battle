using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GeneralInput : MonoBehaviour
{
    public Vector3 mousePos;
    public LayerMask layerMask;
    public GameObject selectedObject;
    private RaycastHit[] _raycastHits;
    private Boolean isDragging;
    public float correctDistanceForZ = 2.61f;
    private GameObject lastHoveredCard;
    private bool isHovered;

    public GameObject box_ref; //tamamen her seferinde getcomponent ile almayalim diye

    private void Start()
    {
        isHovered = false;
    }
    private void Update()
    {
        
        /*RaycastHit hit;
        if (Physics.Raycast(transform.position, mousePos, out hit, Mathf.Infinity,mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }*/

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,15 * ray.direction,Color.green);

        _raycastHits = Physics.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, layerMask);

        
        if (Input.GetMouseButtonDown(0) & _raycastHits.Length>0 & _raycastHits[0].transform.gameObject.CompareTag("Card")) 
        {   //mouse sol tık basılıyor.Basılırken eğer kutu içinde olursa da kutu referansı box_ref içine kayıt ediliyor
             selectedObject = _raycastHits[0].transform.gameObject;
             Debug.Log(selectedObject.name);
             isDragging = true;
             box_ref = selectedObject.gameObject.GetComponent<Card>().forBox;
        }else if (Input.GetMouseButtonUp(0) & isDragging) 
        {           //mouse sol tık bırakılıyor.
            isDragging = false;
            if (selectedObject.gameObject.GetComponent<Card>().isInBox)
            {
                box_ref = selectedObject.gameObject.GetComponent<Card>().forBox;
            }
            else
            {
                box_ref = null;
            }
        }else if (_raycastHits[0].transform.gameObject.CompareTag("Card"))
        {
            GameObject card = _raycastHits[0].transform.gameObject;
            if (card != lastHoveredCard)
            {
                lastHoveredCard.GetComponent<CardAnimator>().unHover();
                card.GetComponent<CardAnimator>().hover();
                isHovered = true;
                lastHoveredCard = card;
            }
            
            //Hover methodunu çağır
        }
        
        Debug.Log("temp card icin " + box_ref);
        if (selectedObject.gameObject.GetComponent<Card>().isInBox && isDragging==false) 
        {           //mouse sol click bırakılmış ve kutu içindeyse ortala
            selectedObject.transform.position = box_ref.transform.position;
        }

        if (isDragging) 
        {          //mouse sol click basılı sürüklüyoruz
            selectedObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, correctDistanceForZ));
        }

        
    } 
}
