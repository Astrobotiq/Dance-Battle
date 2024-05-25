using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantCardBoxOnScreen : MonoBehaviour
{
    public CardStructure structure;
    private GameObject theCardInBox;
    [SerializeField]
    private PlayAreaHandler playAreaHandler;
    [SerializeField]
    private int index;
    public HandHolder handHolder;
    public DiscardHolder discardHolder;
    private void OnTriggerEnter(Collider other)
    {
        theCardInBox = other.gameObject;
        Card card = theCardInBox.GetComponent<Card>();

        if (playAreaHandler != null && card != null && structure.Equals(card.GetCardStructure()))
        {
            StartCoroutine(delayCardEffect(card));
        }
    }

    IEnumerator delayCardEffect(Card card)
    {
        yield return new WaitForSeconds(1f); 
        handHolder.Remove(card);
        //playAreaHandler.addAnim(card.GetAnimationClip());
        CardInfo cardInfo = card.GetCardInfo();
        List<_Effect> effects = cardInfo.getEffect();
        foreach (_Effect effect in effects)
        {
            effect.PlayEffect();
        }
        discardHolder.Add(cardInfo);
        Destroy(theCardInBox);
    }
}
