using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardHolder : _CardHolder
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override Card Draw()
    {
        throw new System.NotImplementedException();
    }

    public List<Card> giveAllCards()
    {
        shuffle();
        List<Card> temp = _cards;
        _cards.Clear();
        return temp;
    }
}
