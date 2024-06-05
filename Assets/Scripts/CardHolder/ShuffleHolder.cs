using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleHolder : _CardHolder
{
    [SerializeField] private CardBaseHolder holder;
    [SerializeField]
    private DiscardHolder discardHolder;
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(delayCardDraw());
    }

    IEnumerator delayCardDraw()
    {
        yield return new  WaitForSeconds(0.5f);
        for (int i = 0; i < 10; i++)
        {
            _cards.Add(holder.Draw());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override CardInfo Draw()
    {
        if(_cards.Count == 0)
        {
            getAllCards();
        }
        CardInfo tempCard = _cards[0];
        Remove(tempCard);
        return tempCard;
    }

    public void getAllCards()
    {
        List<CardInfo> cards = discardHolder.giveAllCards();
        foreach(CardInfo card in cards)
        {
            Add(card);
        }
        Debug.Log("Card's cound "+_cards.Count);
    }
}
