using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    public ArrayList arrayList;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Geçici_Kart")
        {
            Vector3 temp = gameObject.transform.position;
            other.gameObject.transform.position= temp;
            arrayList.Add(other.gameObject);
            Debug.Log("added to arraylist and transformed to center");
        }
    }
}
