using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    BattleState currentState;
    

    public void enterState()
    {
        Debug.Log("current state'e giriyom");
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
            Debug.Log("current state boþ deðil");
            exitState();
        }
        Debug.Log("current state boþ " + newState.name);
        currentState = newState;
        enterState();
    }
}
