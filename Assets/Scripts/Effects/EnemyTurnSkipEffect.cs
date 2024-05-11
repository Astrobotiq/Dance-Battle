using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/EnemyTurnSkipEffect")]
public class EnemyTurnSkipEffect : _Effect
{
    public override void PlayEffect()
    {
        GameObject gameObject = GameObject.FindWithTag("GameBrain");
        gameObject.GetComponent<EnemyTurnState>().setIsSkippingTrue();
    }
}
