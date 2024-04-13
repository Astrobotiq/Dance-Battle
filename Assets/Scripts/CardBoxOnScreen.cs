using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoxOnScreen : MonoBehaviour
{
    [SerializeField]
    private int index;
    [SerializeField]
    private PlayAreaHandler playAreaHandler;
    private GameObject theCardInBox;
    private void OnTriggerEnter(Collider other)
    {
        theCardInBox = other.gameObject;
        Card card = theCardInBox.GetComponent<Card>();
        playAreaHandler.addAnim(card.getAnimationClip(),index);
    }

    private void OnTriggerExit(Collider other)
    {
        playAreaHandler.removeAnim(index);
        theCardInBox = null;
    }

    public GameObject getTheCardInBox()
    {
        return theCardInBox;
    }
}
