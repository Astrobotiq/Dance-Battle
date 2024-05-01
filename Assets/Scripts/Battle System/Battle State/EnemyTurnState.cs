using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : BattleState
{
    public static event StateAction onEnemyTurnStart;
    public static event StateAction onEnemyTurnEnd;
    public override void EnterState()
    {
        Debug.Log("Enemy Turn Ba�lad�. Hurraa");
        onEnemyTurnStart?.Invoke();
        
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

    


}
