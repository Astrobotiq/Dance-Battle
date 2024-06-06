using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdTurnState : BattleState
{
    public static event StateAction onCrowdEnter;
    public static event StateAction onCrowdExit;
    public static event UIAction onUIOpened;
    public static event UIAction onUIClosed;
    public override void EnterState()
    {
        Debug.Log("Croed Turn State baþladý");
        onUIOpened?.Invoke("CROWD");
        StartCoroutine(enterStateDelay());
    }

    public override void ExitState()
    {
        Debug.Log("Croed Turn State bidi");
        onCrowdExit?.Invoke();//Crowd will return to normal for next turn.
    }

    public override void updateState()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator enterStateDelay()
    {
        yield return new WaitForSeconds(2);
        onUIClosed?.Invoke("CROWD");
        onCrowdEnter?.Invoke();//UI will show total point we have in that turn
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        Debug.Log("delay içi");
        yield return new WaitForSeconds(10);
        ExitState();
    }
}
