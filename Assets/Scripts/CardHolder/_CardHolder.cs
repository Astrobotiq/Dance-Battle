using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _CardHolder : MonoBehaviour
{
    [SerializeField]
    protected List<CardInfo> _cards;
    // Start is called before the first frame update
    public CardInfo Draw(CardInfo card)
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

    public abstract CardInfo Draw();

    public virtual void Add(CardInfo card)
    {
        _cards.Add(card);
    }

    public void Remove(CardInfo card)
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

    public void Shuffle()
    {
        List<CardInfo> list = new List<CardInfo>();
        while (_cards.Count > 0)
        {
            int randomNum = Random.Range(0, _cards.Count);
            list.Add(_cards[randomNum]);
            _cards.RemoveAt(randomNum);
        }
        _cards = list;
    } 
}
