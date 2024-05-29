using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : BattleState
{
    public static event StateAction onEnter;
    public static event StateAction onExit;
    public override void EnterState()
    {
        Debug.Log("Win state girildi");
        StartCoroutine(delay());
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void updateState()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(5);
        onEnter?.Invoke();
        Debug.Log("Event yollandý");
    }
}
