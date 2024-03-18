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

    public override Card Draw()
    {
        Card tempCard = _cards[0];
        Remove(tempCard);
        return tempCard;
    }
}
