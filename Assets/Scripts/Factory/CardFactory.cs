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

    private void Awake()
    {
        if (cardPrefab == null)
        {
            Debug.Log("There are no Prefab");
        }
    }

    public void build(CardInfo card)
    {
        if (card != null && cardPrefab != null)
        {
            cardPrefab.GetComponent<Card>().setCardInfo(card);
            Instantiate(cardPrefab);
        }
    }

    public void getCard()
    {
        CardInfo card = shuffleHolder.Draw();
        if (card != null)
        {
            build(card);
        }
    }
}
