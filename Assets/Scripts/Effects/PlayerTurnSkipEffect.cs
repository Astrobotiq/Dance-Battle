using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/PlayerTurnSkipEffect")]
public class PlayerTurnSkipEffect : _Effect
{
    public override void PlayEffect()
    {
        GameObject gameObject = GameObject.FindWithTag("GameBrain");
        gameObject.GetComponent<PlayerTurnState>().setIsSkippingTrue();
    }
}
