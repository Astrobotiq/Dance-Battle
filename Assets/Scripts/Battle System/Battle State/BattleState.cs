using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState:MonoBehaviour
{
    public float time;
    //Add Týmer UI class for timer
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
            //Týmer.setTýme(time);
        }
        ExitState();
        yield return null;
    }
}
