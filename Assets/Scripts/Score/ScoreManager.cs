using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    private List<int> scoreList;
    private bool isNext;
    private bool isAll;
    private float nextMultiplier;
    private float allMultiplier;
    [SerializeField] private int score;
    GameBrain gameBrain;

    public delegate void isNextPlayed(bool isNext);
    public static event isNextPlayed onIsNext;
    public static event Action<int> onSendTotal;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject brainObject = Ga
        nextMultiplier = 1;
        allMultiplier = 1;
    }

    public void Awake()
    {
        scoreList = new List<int>();
    }

    public void addToScore(int point)
    {
        if (isNext)
        {
            point = (int)(point * nextMultiplier);
            nextMultiplier = 1;
            isNext = false;
            onIsNext?.Invoke(isNext);
        }
        score += point;
    }

    public void sendTotalPoint()
    {
        if (isAll)
        {
            score = (int)(score * allMultiplier);
            isAll = false;
            allMultiplier = 1;
        }
        Debug.Log("score:" + score);
        scoreList.Add(score);
        onSendTotal?.Invoke(score); 
        score = 0;
    }

    public void checkColorCombo()
    {
        //List<CardColor> colorsFromCard = 
    }

    public void setIsNext(float multiplier)
    {
        isNext = true;
        nextMultiplier = multiplier;
        //onIsNext?.Invoke(isNext);
    }

    public void setIsAll(float multiplier)
    {
        isAll = true;
        allMultiplier = multiplier;
    }

    public int getLastListIndex()
    {
        return scoreList[scoreList.Count - 1];
    }

    public bool isScoreListEmpty()
    {
        if (scoreList.Count == 0)
        {
            return true;
        }

        return false;
    }

    private void OnEnable()
    {
        CrowdTurnState.onCrowdEnter += sendTotalPoint;
    }

    private void OnDisable()
    {
        CrowdTurnState.onCrowdEnter -= sendTotalPoint;
    }
    

}
