using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoxOnScreen : MonoBehaviour
{
    private GameObject theCardInBox;
    private void OnTriggerEnter(Collider other)
    {
        theCardInBox = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        theCardInBox = null;
    }

    public GameObject getTheCardInBox()
    {
        return theCardInBox;
    }
}
