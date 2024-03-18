using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _CardHolder : MonoBehaviour
{
    protected List<Card> _cards;
    // Start is called before the first frame update
    public Card Draw(Card card)
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

    public abstract Card Draw();

    public void Add(Card card)
    {
        _cards.Add(card);
    }

    public void Remove(Card card)
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

    public void shuffle()
    {
        List<Card> list = new List<Card>();
        while (_cards.Count > 0)
        {
            int randomNum = Random.Range(0, _cards.Count);
            list.Add(_cards[randomNum]);
            _cards.RemoveAt(randomNum);
        }
        _cards = list;
    } 
}
