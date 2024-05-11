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
    public int howManyTurn;

    
    private void Start()
    {
        battleSystem = GetComponent<BattleSystem>();
        index = -1;
        setBattleState();
        currentTurn = 0;
        effects = new Dictionary<int, List<_Effect>>();
        FillDictionary();
    }

    public void setBattleState()
    {
        Debug.Log("State Ba�lad�");
        getNextIndex();
        battleSystem.stateTransition(GetState());
    }

    public void startCoroutine()
    {
        StartCoroutine(effectSender());
    }

    public void addEffects(List<List<_Effect>> effects_input)
    {
        foreach (List<_Effect> effectList in effects_input)
        {
            //Debug.Log(effectList.Count + " naber " + effects_input.Count);
            foreach (_Effect effect in effectList)
            {
                //Debug.Log(effect.description +" naber naber " + effectList.Count);
                int effect_delay = effect.getDelay();
                //Debug.Log("naber naber naber effect" + effect_delay );
                //Debug.Log("naber naber naber current" + currentTurn);
                effects[effect_delay + currentTurn].Add(effect);
            }
        }
    }

    IEnumerator effectSender()
    {
        if (effects != null)
        {
            List<_Effect> tempEffects = effects[currentTurn];


            foreach (var effect in tempEffects)
            {
                Debug.Log("naber size " + tempEffects.Count);
                effect.PlayEffect();
                Debug.Log("effect sender ici " + effect.name);
                yield return new WaitForSeconds(1f);
            }
        }
        Debug.Log("Game Brain i�i state transition ba�lat�lacak");
        setBattleState();
    }

    public void FillDictionary()
    {
        for (int i = 0; i < howManyTurn; i++)
        {
            List<_Effect> temp = new List<_Effect>();
            effects[i] = temp;
        }
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
