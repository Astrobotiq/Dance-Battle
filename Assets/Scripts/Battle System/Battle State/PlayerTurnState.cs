using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : BattleState
{
    public static event StateAction onPlayerTurnStart;
    public static event StateAction onPlayerTurnEnd;
    public override void EnterState()
    {
        if (onPlayerTurnStart != null)
        {
            onPlayerTurnStart();
        }
    }

    public override void ExitState()
    {
        if (onPlayerTurnEnd != null)
        {
            onPlayerTurnEnd();
        }
    }

    public override void updateState()
    {
        
    }
}
