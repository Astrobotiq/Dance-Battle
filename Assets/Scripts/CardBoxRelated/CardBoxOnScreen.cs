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
    public HandHolder handHolder;
    public CardStructure cardStructure;
    
    private void OnTriggerEnter(Collider other)
    {
        theCardInBox = other.gameObject;
        Card card = theCardInBox.GetComponent<Card>();

        if(playAreaHandler != null && card != null && cardStructure.Equals(card.GetCardStructure()))
        {
            handHolder.Remove(card);
            playAreaHandler.addAnim(card.GetAnimationClip(),index);//for animation
            playAreaHandler.addEffect(card.getEffect(), index); //for effect
        }
    }

    private void OnTriggerExit(Collider other)
    {
        theCardInBox = other.gameObject;
        Card card = theCardInBox.GetComponent<Card>();

        if (playAreaHandler != null && card != null)
        {
            playAreaHandler.removeAnim(card.GetAnimationClip()); //for animation
            playAreaHandler.removeEffect(card.getEffect()); //for effect
            handHolder.Add(card);
        }
        theCardInBox = null;
    }

    public GameObject getTheCardInBox()
    {
        return theCardInBox;
    }
    
}
