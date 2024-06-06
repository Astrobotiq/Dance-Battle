using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/Additional Card Effect")]
public class AdditionalCardEffect : _Effect
{
    public int additionAmount;
    
    public override void PlayEffect()
    {
        GameObject player = GameObject.FindWithTag("PlayerHand");
        HandHolder hh = player.GetComponent<HandHolder>();
        hh.setMaxCard(additionAmount);
    }
}
