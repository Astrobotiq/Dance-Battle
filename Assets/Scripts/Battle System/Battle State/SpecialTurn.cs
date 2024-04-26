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
        onExitSpecial?.Invoke();
    }

    public override void updateState()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator timer()
    {
        for (float time = 10; time >= 0; time -= Time.deltaTime)
        {
            //Add UI some timer component
            //Týmer.setTýme(time);
            Debug.Log("Time : " + time);
            yield return null;
        }
        ExitState();
    }
}
