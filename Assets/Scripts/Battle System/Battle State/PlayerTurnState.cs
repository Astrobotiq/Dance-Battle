using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : BattleState
{
    public PlayerTurnState(float time) : base(time)
    {
    }

    public static event StateAction onPlayerTurnStart;
    public static event StateAction onPlayerTurnEnd;
    public override void EnterState()
    {
        if (onPlayerTurnStart != null)
        {
            onPlayerTurnStart();
            StartCoroutine(timer());
        }
    }

    public override void ExitState()
    {
        if (onPlayerTurnEnd != null)
        {
            onPlayerTurnEnd();
            StopCoroutine (timer());
        }
    }

    public override void updateState()
    {
        
    }

    
}
