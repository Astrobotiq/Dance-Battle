using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdTurnState : BattleState
{
    public static event StateAction onCrowdEnter;
    public static event StateAction onCrowdExit;
    public override void EnterState()
    {
        Debug.Log("Croed Turn State baþladý");
        onCrowdEnter?.Invoke();//UI will show total point we have in that turn
        StartCoroutine(delay());
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

    IEnumerator delay()
    {
        Debug.Log("delay içi");
        yield return new WaitForSeconds(5);
        ExitState();
    }
}
