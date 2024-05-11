using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : BattleState
{
    public static event StateAction onEnemyTurnStart;
    public static event StateAction onEnemyTurnEnd;

    public bool isSkipping = false;
    public override void EnterState()
    {
        Debug.Log("Enemy Turn Ba�lad�. Hurraa");
        if (isSkipping)
        {
            isSkipping = false;
            ExitState();
        }
        else
        {
            onEnemyTurnStart?.Invoke();
        }
    }

    public override void ExitState()
    {
        if (onEnemyTurnEnd != null)
        {
            onEnemyTurnEnd?.Invoke();
        }
    }

    public override void updateState()
    {
        throw new System.NotImplementedException();
    }

    public void setIsSkippingTrue()
    {
        isSkipping = true;
    }
}
