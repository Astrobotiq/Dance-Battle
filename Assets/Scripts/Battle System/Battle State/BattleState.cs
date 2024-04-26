using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState:MonoBehaviour
{
    public float time;
    //Add T�mer UI class for timer
    public delegate void StateAction();

    public BattleState(float time)
    {
        //Instansiate UITimer here
        this.time = time;
    }
    public abstract void EnterState();

    public abstract void updateState();

    public abstract void ExitState();

    public IEnumerator timer()
    {
        for (; time >= 0; time = Time.deltaTime)
        {
            //Add UI some timer component
            //T�mer.setT�me(time);
        }
        ExitState();
        yield return null;
    }
}
