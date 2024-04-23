using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBrain : MonoBehaviour
{
    BattleSystem battleSystem;
    List<BattleState> battleStates;
    int index;

    private void Start()
    {
        battleSystem = GetComponent<BattleSystem>();
        battleStates = new List<BattleState>();
        index = 0;
        battleStates.Add(new PlayerTurnState());
        battleStates.Add(new EnemyTurnState());
        setBattleState();
    }

    public void setBattleState()
    {
        battleSystem.stateTransition(GetState());
        getNextIndex();
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
    }




}
