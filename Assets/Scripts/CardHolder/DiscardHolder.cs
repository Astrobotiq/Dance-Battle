using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardHolder : _CardHolder
{
    public ShuffleHolder ShuffleHolder;
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
        throw new System.NotImplementedException();
    }

    public List<CardInfo> giveAllCards()
    {
        Shuffle();
        List<CardInfo> temp = new List<CardInfo>();
        foreach(CardInfo card in _cards)
        {
            temp.Add(card);
        }
        if (temp != null)
        {
            _cards.Clear();
        }
        return temp;
    }

    public void onWin()
    {
        foreach(CardInfo card in _cards)
        {
            ShuffleHolder.Add(card);
        }
    }
    private void OnEnable()
    {
        UIManager.onWin += onWin;
    }
}
