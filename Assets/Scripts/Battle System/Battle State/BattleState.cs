using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState
{
    public delegate void StateAction();
    public abstract void EnterState();

    public abstract void updateState();

    public abstract void ExitState();
}
