using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAreaHandler : MonoBehaviour
{
    public GameObject playerTurnBox;
    public GameObject enemyTurnBox;
    public List<AnimationClip> animations;
    public List<List<_Effect>> effects;
    [SerializeField] private AnimationHandler animationHandler;
    [SerializeField]
    private GameBrain gameBrain;
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
    }

    private void OnDisable()
    {
        SpecialTurn.onEnterSpecial -= enableEnemyTurnCardArea;
        SpecialTurn.onExitSpecial -= disableEnemyTurnCardArea;
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
        Debug.Log("Box aktive edilecek");
        
        playerTurnBox.gameObject.SetActive(false);
        enemyTurnBox.gameObject.SetActive(true) ;
    }

    public void disablePlayerTurnCardArea()
    {
        removeCards();
        playerTurnBox.gameObject.SetActive(false);
    }

    public void disableEnemyTurnCardArea()
    {

        Debug.Log("Box deaktive edilecek");
        enemyTurnBox.gameObject.SetActive(false);
        playerTurnBox.gameObject.SetActive(true);
    }

    public void removeCards()
    {
        Debug.Log("Kartlar silinecek");
        CardBoxOnScreen[] cardGO = playerTurnBox.GetComponentsInChildren<CardBoxOnScreen>();
        foreach(CardBoxOnScreen box in cardGO)
        {
            Destroy(box.getTheCardInBox());
        } 
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
        Debug.Log("from player area handler effects len : " + effects.Count);
    }

    public void removeEffect(List<_Effect> effect)
    {
        if (effects.Contains(effect))
        {
            effects.Remove(effect);
        }
    }

    public void sendEffects()
    {
        gameBrain.addEffects(effects);
        effects.Clear();
    }

    public Boolean CanPlay()
    {
        Debug.Log("Effects length in Can Play:" + effects.Count);
        if (effects.Count == 3 && animations.Count == 3)
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
        }
    }
    
}
