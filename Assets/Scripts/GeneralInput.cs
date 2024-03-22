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

    public GameObject box_ref; //tamamen her seferinde getcomponent ile almayalim diye
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
        
        if(Input.GetMouseButtonDown(0)) 
        {   //mouse sol tık basılıyor.Basılırken eğer kutu içinde olursa da kutu referansı box_ref içine kayıt ediliyor
            _raycastHits = Physics.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, layerMask);
            //selectedObject = _raycastHits[0].transform.gameObject;
            //Debug.Log(selectedObject.tag);

            if (_raycastHits[0].collider != null)
            {
                selectedObject = _raycastHits[0].transform.gameObject;
                Debug.Log(selectedObject.name);
                isDragging = true;
                box_ref = selectedObject.gameObject.GetComponent<Card>().forBox;
            }

        }
        
        if (Input.GetMouseButtonUp(0)) 
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
