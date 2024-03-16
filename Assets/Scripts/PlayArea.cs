using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    //array initialize edilmemi�
    //play arealarin oldu�u colliderlar isTrigger olacak
    //Card'in isTriggerini de�i�tir
    public ArrayList arrayList;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Card")
        {
            Vector3 temp = gameObject.transform.position;
            other.gameObject.transform.position= temp;
            arrayList.Add(other.gameObject);
            Debug.Log("added to arraylist and transformed to center");
        }
    }
}
