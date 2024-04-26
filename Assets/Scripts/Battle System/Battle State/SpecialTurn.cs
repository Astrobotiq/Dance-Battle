using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTurn : BattleState
{
    public SpecialTurn(float time) : base(time) { }
   

    public static event StateAction onEnterSpecial;
    public static event StateAction onExitSpecial;

    public override void EnterState()
    {
        if (onEnterSpecial != null)
        {
            onEnterSpecial.Invoke();
            StartCoroutine(timer());
        }
    }

    public override void ExitState()
    {
        if (onExitSpecial != null)
        {
            onExitSpecial.Invoke();
            StopCoroutine(timer());
        }
    }

    public override void updateState()
    {
        throw new System.NotImplementedException();
    }

    
    
}
