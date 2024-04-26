using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : BattleState
{
    public static event StateAction onEnemyTurnStart;
    public static event StateAction onEnemyTurnEnd;
    public override void EnterState()
    {
        if (onEnemyTurnStart != null)
        {
            onEnemyTurnStart();
        }
    }

    public override void ExitState()
    {
        if (onEnemyTurnEnd != null)
        {
            onEnemyTurnEnd();
        }
    }

    public override void updateState()
    {
        throw new System.NotImplementedException();
    }


    public EnemyTurnState(float time) : base(time)
    {
    }
}