using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantCardBoxOnScreen : MonoBehaviour
{
    private GameObject theCardInBox;
    [SerializeField]
    private PlayAreaHandler playAreaHandler;
    [SerializeField]
    private int index;
    public HandHolder handHolder;
    private void OnTriggerEnter(Collider other)
    {
        theCardInBox = other.gameObject;
        Card card = theCardInBox.GetComponent<Card>();

        if (playAreaHandler != null && card != null)
        {
            handHolder.Remove(card);
            playAreaHandler.addAnim(card.GetAnimationClip());
            Destroy(card);
        }
    }
}
