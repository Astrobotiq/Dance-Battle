using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _CardHolder : MonoBehaviour
{
    protected List<Card> _cards;
    // Start is called before the first frame update
    public abstract Card Draw(Card card);

    public abstract void Add(Card card);

    public abstract void Remove(Card card);

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
