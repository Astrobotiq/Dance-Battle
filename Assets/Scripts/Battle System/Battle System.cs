using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    BattleState currentState;
    

    public void enterState()
    {
        currentState.EnterState();
    }

    public void exitState()
    {
        currentState.ExitState();
    }

    public void stateTransition(BattleState newState)
    {
        if (currentState != null)
        {
            exitState();
        }
        currentState = newState;
        enterState();
    }
}