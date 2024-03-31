using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    //This class will implemented as soon as possible.Probably on week 2
    //We will use it as instantiator of cards
    [SerializeField]
    private GameObject cardPrefab;
    [SerializeField]
    private ShuffleHolder shuffleHolder;
    [SerializeField]
    private HandHolder handHolder;
    public Transform BornPos;

    private void Awake()
    {
        if (cardPrefab == null)
        {
            Debug.Log("There are no Prefab");
        }
    }

    /*public void build(CardInfo card)
    {
        Debug.Log("Build has been entered");
        if (card != null && cardPrefab != null)
        {
            Debug.Log("if has been entered");
            GameObject cardObject= cardPrefab;
            if (cardObject != null)
            {
                Debug.Log("Card Name" + card.CardName + " Card Type: " + card.CardType);
                cardObject.AddComponent<Card>().setCardInfo(card);
            }
            Debug.Log("if has been exited");
            Instantiate(cardObject,BornPos);
            //handHolder.Add(cardPrefab.GetComponent<Card>());
        }
    }*/

    public void build(CardInfo card)
    {
        Debug.Log("Build has been entered");
        if (card != null && cardPrefab != null)
        {
            Debug.Log("if has been entered");

            // Instantiate a new GameObject based on the cardPrefab
            GameObject cardObject = Instantiate(cardPrefab, BornPos.position, Quaternion.identity);

            if (cardObject != null)
            {
                Debug.Log("Card Name: " + card.CardName + " Card Type: " + card.CardType);
                cardObject.AddComponent<Card>().setCardInfo(card);
            }

            Debug.Log("if has been exited");
            
            handHolder.Add(cardObject.GetComponent<Card>());
        }
    }

    public void getCard()
    {
        CardInfo card = shuffleHolder.Draw();
        if (card != null)
        {
            Debug.Log("Card taken");
            build(card);
        }
    }
}
