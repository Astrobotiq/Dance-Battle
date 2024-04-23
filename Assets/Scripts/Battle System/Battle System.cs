using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    BattleState currentState;

    private void Awake()
    {
        currentState = new PlayerTurnState();
        enterState();
    }

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
