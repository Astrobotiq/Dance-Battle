using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleHolder : _CardHolder
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override Card Draw(Card card)
    {
        if (_cards.Contains(card))
        {
            return card;
        }
        else
        {
            Debug.Log("You cannot Find What you are looking for");
            return null;
        }
    }

    public override void Add(Card card)
    {
        _cards.Add(card);
    }

    public override void Remove(Card card)
    {
        if (!_cards.Contains(card))
        {
            Debug.Log("You cannot Find What you are looking for");
        }
        else
        {
            _cards.Remove(card);
        }
    }


}
