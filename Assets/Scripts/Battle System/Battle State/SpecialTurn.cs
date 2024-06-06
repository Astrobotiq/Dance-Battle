using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecialTurn : BattleState
{

    public static event StateAction onEnterSpecial;
    public static event StateAction onExitSpecial; 
    public static event UIAction onUIOpened;
    public static event UIAction onUIClosed;

    public override void EnterState()
    {
        onUIOpened?.Invoke("SPECÝAL");
        StartCoroutine(enterStateDelay());
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
        yield return new WaitForSeconds(10);
        ExitState();
    }

    IEnumerator enterStateDelay()
    {
        yield return new WaitForSeconds(2);
        onUIClosed?.Invoke("SPECIAL");
        StartCoroutine(timer());
        onEnterSpecial?.Invoke();
    }
}
