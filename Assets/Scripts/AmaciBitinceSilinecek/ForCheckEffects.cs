using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ForCheckEffects : MonoBehaviour
{
    private List<CardInfo> cards = new List<CardInfo>();
    public GameObject tempUIScore;

    public void PlayStoredEffects()
    {
        foreach (CardInfo cardInfo in cards)
        {
            Debug.Log(cardInfo.CardName + " naber");
            tempUIScore.gameObject.GetComponent<TempScoreScript>().scoreDecrease();
        }
        
    }

    public void AddToCards(CardInfo parameter)
    {
        cards.Add(parameter);
    }
}
