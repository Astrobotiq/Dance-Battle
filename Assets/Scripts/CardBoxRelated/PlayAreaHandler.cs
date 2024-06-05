using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAreaHandler : MonoBehaviour
{
    public GameObject playerTurnBox;
    public GameObject enemyTurnBox;
    public List<AnimationClip> animations;
    public List<CardColor> cardColors;
    public List<List<_Effect>> effects;
    [SerializeField] private AnimationHandler animationHandler;
    [SerializeField]
    private GameBrain gameBrain;
    [SerializeField]  DiscardHolder discardHolder;
    // Start is called before the first frame update
    void Start()
    {
        effects = new List<List<_Effect>>();
        animations = new List<AnimationClip>();
    }

    private void OnEnable()
    {
        SpecialTurn.onExitSpecial += disableEnemyTurnCardArea;
        SpecialTurn.onEnterSpecial += enableEnemyTurnCardArea;
        EnemyTurnState.onEnemyTurnStart += enableEnemyTurnCardArea;
        EnemyTurnState.onEnemyTurnEnd += disableEnemyTurnCardArea;
        PlayerTurnState.onPlayerTurnStart += enablePlayerTurnCardArea;
        PlayerTurnState.onPlayerTurnEnd += disablePlayerTurnCardArea;
    }

    private void OnDisable()
    {
        SpecialTurn.onEnterSpecial -= enableEnemyTurnCardArea;
        SpecialTurn.onExitSpecial -= disableEnemyTurnCardArea;
        EnemyTurnState.onEnemyTurnStart += enableEnemyTurnCardArea;
        EnemyTurnState.onEnemyTurnEnd += disableEnemyTurnCardArea;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void enablePlayerTurnCardArea()
    {
        playerTurnBox.gameObject.SetActive(true);
    }

    public void enableEnemyTurnCardArea()
    {
        enemyTurnBox.gameObject.SetActive(true) ;
    }

    public void disablePlayerTurnCardArea()
    {
        removeCards();
        playerTurnBox.gameObject.SetActive(false);
    }

    public void disableEnemyTurnCardArea()
    {
        enemyTurnBox.gameObject.SetActive(false);
    }

    public void removeCards()
    {
        Debug.Log("Kartlar silinecek");
        CardBoxOnScreen[] cardGO = playerTurnBox.GetComponentsInChildren<CardBoxOnScreen>();
        foreach(CardBoxOnScreen box in cardGO)
        {
            CardInfo cardInfo = box.getTheCardInBox().GetComponent<Card>().GetCardInfo();
            sendCardToDiscard(cardInfo);
            Destroy(box.getTheCardInBox());
        } 
    }

    public void sendCardToDiscard(CardInfo info)
    {
        discardHolder.Add(info);
    }

    public void addAnim(AnimationClip clip, int index)
    {
        animations.Insert(index, clip);
    }

    public void addAnim(AnimationClip clip)
    {
        animationHandler.playInstantAnim(clip);
    }

    public void removeAnim(AnimationClip clip)
    {
        if(animations.Contains(clip))
        {
            animations.Remove(clip);
        }
        
    }

    public void sendAnim()
    {
        animationHandler.addAnimation(animations);
        animations.Clear();
    }

    public void addEffect(List <_Effect> effect,int index)
    {
        Debug.Log("from player area handler " + effect.Count);
        effects.Insert(index, effect);
        foreach (_Effect naber in effect)
        {
            Debug.Log("from index " + index + " the effect is " + naber.name);
        }
        Debug.Log("from player area handler effects len : " + effects.Count);
    }

    public void removeEffect(List<_Effect> effect)
    {
        if (effects.Contains(effect))
        {
            effects.Remove(effect);
        }
    }

    public void addCardColor(CardColor color, int index)
    {
        Debug.Log("from player area handler card color : " + cardColors.Count);
        cardColors.Insert(index, color);
        Debug.Log("from player area handler card color len : " + effects.Count);
    }

    public void removeCardColor(int index)
    {
        if (cardColors[index] != null)
        {
            cardColors.RemoveAt(index);
        } 
        
    }

    public void sendEffects()
    {
        gameBrain.addEffects(effects);
        effects.Clear();
    }

    public void sendColors()
    {
        gameBrain.addColors(cardColors);
        cardColors.Clear();
    }

    public Boolean CanPlay()
    {
        Debug.Log("Effects length in Can Play:" + effects.Count);
        Debug.Log("card colors length in Can Play:" + cardColors.Count);
        if (effects.Count == 3 && animations.Count == 3 && cardColors.Count == 3)
        {
            return true;
        }
        
        return false;
    }
    
    public void finishTurn()
    {
        Debug.Log("can play result" + CanPlay());
        if (CanPlay())
        {
            sendAnim();
            sendEffects();
            sendColors();
        }
    }
    
}
