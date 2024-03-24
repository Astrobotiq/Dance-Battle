using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleHolder : _CardHolder
{
    [SerializeField]
    private DiscardHolder discardHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override CardInfo Draw()
    {
        CardInfo tempCard = _cards[0];
        Remove(tempCard);
        return tempCard;
    }

    public void getAllCards()
    {
        _cards = discardHolder.giveAllCards();
    }
}
