using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBaseHolder : _CardHolder
{
    public List<List<CardInfo>> allCards;
    public List<CardInfo> red;
    public List<CardInfo> purple;
    public List<CardInfo> pink;

    private void Start()
    {
        allCards = new List<List<CardInfo>>();
        allCards.Add(red); allCards.Add(pink); allCards.Add(purple); allCards.Add(_cards);
    }
    public override CardInfo Draw()
    {
        int rand = Random.Range(0,allCards.Count);
        int random = Random.Range(0, allCards[rand].Count);
        return allCards[rand][random];
    }
}
