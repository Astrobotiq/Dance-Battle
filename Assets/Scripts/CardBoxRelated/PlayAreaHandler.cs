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
        
        animations = new List<AnimationClip>();
    }

    private void OnEnable()
    {
        Debug.Log("On Enable 1");
        SpecialTurn.onExitSpecial += disableEnemyTurnCardArea;
        Debug.Log("On Enable 2");
        SpecialTurn.onEnterSpecial += enableEnemyTurnCardArea;
        Debug.Log("On Enable 3");
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
        playerTurnBox.SetActive(true);
    }

    public void enableEnemyTurnCardArea()
    {
        Debug.Log("Box aktive edilecek");
        
        playerTurnBox.gameObject.SetActive(false);
        enemyTurnBox.gameObject.SetActive(true) ;
    }

    public void disablePlayerTurnCardArea()
    {
        playerTurnBox.SetActive(false);
    }

    public void disableEnemyTurnCardArea()
    {

        Debug.Log("Box deaktive edilecek");
        enemyTurnBox.gameObject.SetActive(false);
        playerTurnBox.gameObject.SetActive(true);
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
