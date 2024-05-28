using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private BattleState currentState;
    [SerializeField] private UIManager UIManagerInstance;
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
        
        Debug.Log("current state bos " + newState.name);
        currentState = newState;
        UIManagerInstance.updateUI();
        enterState();
    }

    public BattleState getState()
    {
        return currentState;
    }
}
