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
    public float yMinValue;
    private GameObject lastHoveredCard;
    private bool isHovered;

    public GameObject box_ref; //tamamen her seferinde getcomponent ile almayalim diye

    private void Start()
    {
        isHovered = false;
        isDragging = false;
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

        _raycastHits = Physics.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, layerMask);

        
        if (Input.GetMouseButton(0)) 
        {   //mouse sol tık basılıyor.Basılırken eğer kutu içinde olursa da kutu referansı box_ref içine kayıt ediliyor
            Debug.Log("1");
            if (_raycastHits.Length > 0) //just to solve red debug log warning
            {
                if (_raycastHits.Length > 0 & _raycastHits[0].transform.gameObject.CompareTag("Card"))
                {
                    selectedObject = _raycastHits[0].transform.gameObject;
                    isDragging = true;
                    box_ref = selectedObject.gameObject.GetComponent<Card>().forBox;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0) & isDragging) 
        {           //mouse sol tık bırakılıyor.
            Debug.Log("2");
            isDragging = false;
            if (selectedObject.gameObject.GetComponent<Card>().isInBox)
            {
                box_ref = selectedObject.gameObject.GetComponent<Card>().forBox;
            }
            else
            {
                box_ref = null;
            }
        }
        else if (_raycastHits.Length > 0) //just to solve red debug log warning
        {
            if (_raycastHits.Length > 0 & _raycastHits[0].transform.gameObject.CompareTag("Card"))
            {
                Debug.Log("3");
                GameObject card = _raycastHits[0].transform.gameObject;
            
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    card.GetComponent<CardAnimator>().hover();
                    isHovered = true;
                    lastHoveredCard = card;
                }
                else if (Input.GetKey(KeyCode.LeftControl))
                {
                
                }
                else
                {
                    if (lastHoveredCard != null)
                    {
                        lastHoveredCard.GetComponent<CardAnimator>().unHover();
                    }
                    isHovered = false;
                    lastHoveredCard = null;
                }
            }
        }
        //Debug.Log(selectedObject.GetComponent<Card>().isInBox);
        
        //konsolda kırmızı hata veriyor oyun yeni başlayıp henüz hiçbir kart seçilmediğinde
        if (selectedObject.gameObject.GetComponent<Card>().isInBox && !isDragging) {   //mouse sol click bırakılmış ve kutu içindeyse ortala
            selectedObject.transform.position = box_ref.transform.position;
        }
        
        if (isDragging) 
        {          //mouse sol click basılı sürüklüyoruz
            selectedObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, correctDistanceForZ));
            Vector3 temp = selectedObject.transform.position;
            if (temp.y < yMinValue)
            {
                temp.y = yMinValue;
                selectedObject.transform.position = temp;
            }
            
        }
    } 
}
/*
if (Input.GetKeyDown(KeyCode.LeftControl))
{
    card.GetComponent<CardAnimator>().hover();
    isHovered = true;
    lastHoveredCard = card;
}
else if (Input.GetKey(KeyCode.LeftControl))
{
                
}
else
{
    lastHoveredCard.GetComponent<CardAnimator>().unHover();
    isHovered = false;
    lastHoveredCard = null;
}*/

/*
 * else if (_raycastHits.Length > 0 & _raycastHits[0].transform.gameObject.CompareTag("Card"))
        {
            Debug.Log("3");
            GameObject card = _raycastHits[0].transform.gameObject;
            if (lastHoveredCard==null)
            {
                card.GetComponent<CardAnimator>().hover();
                isHovered = true;
                lastHoveredCard = card;
            }
            if (card != lastHoveredCard)
            {
                lastHoveredCard.GetComponent<CardAnimator>().unHover(); 
                /*if (lastHoveredCard != null)
                {
                    lastHoveredCard.GetComponent<CardAnimator>().unHover();
                }* /
                card.GetComponent<CardAnimator>().hover();
                isHovered = true;
                lastHoveredCard = card;
            }
            
            //Hover methodunu çağır
        }
        else //if (!_raycastHits[0].transform.gameObject.CompareTag("Card"))
        {
            Debug.Log("Unhoverlıcam");
            lastHoveredCard.GetComponent<CardAnimator>().unHover();
            lastHoveredCard = null;
        }
 */
