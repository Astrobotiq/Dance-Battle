using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    //array initialize edilmemiþ
    //play arealarin olduðu colliderlar isTrigger olacak
    //Card'in isTriggerini deðiþtir
    Card puttedCard;

    private void Awake()
    {
        puttedCard = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Card")
        {
            Debug.Log(other.gameObject.name);
            Debug.Log(transform.position);
            GameObject otherGO = other.gameObject;
            otherGO.GetComponent<KartMovement>().enabled = false;
            puttedCard = otherGO.GetComponent<Card>();
            otherGO.transform.position = transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Card")
        {
            puttedCard = null;
        }
    }
}
