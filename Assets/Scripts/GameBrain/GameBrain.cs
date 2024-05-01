using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBrain : MonoBehaviour
{
    
    BattleSystem battleSystem;
    public List<BattleState> battleStates;
    int index;

    

    private void Start()
    {
        battleSystem = GetComponent<BattleSystem>();
        index = -1;
        setBattleState();
    }

    public void setBattleState()
    {
        Debug.Log("State Baþladý");
        getNextIndex();
        battleSystem.stateTransition(GetState());
    }

    BattleState GetState()
    {
        return battleStates[index];
    }

    void getNextIndex()
    {
        if (index + 1 >= battleStates.Count)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        Debug.Log("index: "+index);
    }


    private void OnEnable()
    {
        SpecialTurn.onExitSpecial += setBattleState;
        PlayerTurnState.onPlayerTurnEnd += setBattleState;
    }

    private void OnDisable()
    {
        SpecialTurn.onExitSpecial -= setBattleState;
        PlayerTurnState.onPlayerTurnEnd -= setBattleState;
    }




}
