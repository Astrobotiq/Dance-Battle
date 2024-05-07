using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameBrain : MonoBehaviour
{
    
    BattleSystem battleSystem;
    public List<BattleState> battleStates;
    [SerializeField]
    private Dictionary <int,List<_Effect>> effects;
    public int currentTurn;
    int index;

    

    private void Start()
    {
        battleSystem = GetComponent<BattleSystem>();
        index = -1;
        setBattleState();
        currentTurn = 0;
    }

    public void setBattleState()
    {
        Debug.Log("State Baþladý");
        getNextIndex();
        battleSystem.stateTransition(GetState());
    }

    public void startCoroutine()
    {
        StartCoroutine(effectSender());
    }

    IEnumerator effectSender()
    {
        if (effects != null)
        {
            List<_Effect> tempEffects = effects[currentTurn];


            foreach (var effect in tempEffects)
            {
                effect.PlayEffect();
                yield return new WaitForSeconds(1f);
            }
        }
        Debug.Log("Game Brain içi state transition baþlatýlacak");
        setBattleState();
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
        PlayerTurnState.onPlayerTurnEnd += startCoroutine;
        CrowdTurnState.onCrowdExit += setBattleState;
    }

    private void OnDisable()
    {
        SpecialTurn.onExitSpecial -= setBattleState;
        PlayerTurnState.onPlayerTurnEnd -= startCoroutine;
        CrowdTurnState.onCrowdExit -= setBattleState;
    }




}
