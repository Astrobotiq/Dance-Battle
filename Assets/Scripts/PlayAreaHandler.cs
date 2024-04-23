using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAreaHandler : MonoBehaviour
{
    public GameObject playerTurnBox;
    public GameObject enemyTurnBox;
    public List<AnimationClip> animations;
    [SerializeField] private AnimationHandler animationHandler;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTurnState.onPlayerTurnStart += enablePlayerTurnCardArea;
        PlayerTurnState.onPlayerTurnEnd += disablePlayerTurnCardArea;
        EnemyTurnState.onEnemyTurnStart += enableEnemyTurnCardArea;
        EnemyTurnState.onEnemyTurnEnd += disableEnemyTurnCardArea;
        animations = new List<AnimationClip>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void enablePlayerTurnCardArea()
    {
        playerTurnBox.SetActive(true);
    }

    public void enableEnemyTurnCardArea()
    {
        enemyTurnBox.SetActive(true);
    }

    public void disablePlayerTurnCardArea()
    {
        playerTurnBox.SetActive(false);
    }

    public void disableEnemyTurnCardArea()
    {
        enemyTurnBox.SetActive(false);
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
}
