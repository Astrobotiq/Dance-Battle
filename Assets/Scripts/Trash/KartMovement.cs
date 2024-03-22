using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartMovement : MonoBehaviour //Class diagram eklenmedi bu script
{
    public Vector3 mousePos;
    public LayerMask layerMask;
    public GameObject selectedObject;
    private RaycastHit[] _raycastHits;
    private Boolean isDragging;
    public float _float = 3f;
    

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
        {
            _raycastHits = Physics.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, layerMask);
            //selectedObject = _raycastHits[0].transform.gameObject;
            //Debug.Log(selectedObject.tag);

            if (_raycastHits[0].collider != null)
            {
                selectedObject = _raycastHits[0].transform.gameObject;
                Debug.Log(selectedObject.name);
                isDragging = true;
            }

        }

        if (isDragging)
        {
            selectedObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, _float));
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    } 

    /*private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
    }*/
}
