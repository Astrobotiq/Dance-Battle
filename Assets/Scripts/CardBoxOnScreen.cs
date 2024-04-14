using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoxOnScreen : MonoBehaviour
{
    private GameObject theCardInBox;
    [SerializeField]
    private PlayAreaHandler playAreaHandler;
    [SerializeField]
    private int index;
    private void OnTriggerEnter(Collider other)
    {
        theCardInBox = other.gameObject;
        Card card = theCardInBox.GetComponent<Card>();

        if(playAreaHandler != null & card != null)
        {
            playAreaHandler.addAnim(card.GetAnimationClip(),index);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(playAreaHandler != null)
        {
            playAreaHandler.removeAnim(index);
        }
        theCardInBox = null;
    }

    public GameObject getTheCardInBox()
    {
        return theCardInBox;
    }
}
