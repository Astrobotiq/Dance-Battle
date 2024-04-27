using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTurn : BattleState
{

    public static event StateAction onEnterSpecial;
    public static event StateAction onExitSpecial;

    public override void EnterState()
    {
       
        StartCoroutine(timer());
        onEnterSpecial?.Invoke();
        Debug.Log("Timerdan önce");
        
        
    }

    public override void ExitState()
    {
        StopCoroutine(timer());
        onExitSpecial?.Invoke();
    }

    public override void updateState()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator timer()
    {
        yield return new WaitForSeconds(2);
        ExitState();
    }
}
