using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState : MonoBehaviour
{
    //Add Tımer UI class for timer
    public delegate void StateAction();

    
    public abstract void EnterState();

    public abstract void updateState();

    public abstract void ExitState();

    
}
