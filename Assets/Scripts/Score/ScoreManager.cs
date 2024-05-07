using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private List<int> scoreList;
    private bool isNext;
    private bool isAll;
    private float nextMultiplier;
    private float allMultiplier;
    private int score;

    public delegate void isNextPlayed(bool isNext);
    public static event isNextPlayed onIsNext;
    public static event Action<int> onSendTotal;

    // Start is called before the first frame update
    void Start()
    {
        scoreList = new List<int>();
        nextMultiplier = 1;
        allMultiplier = 1;
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
        Debug.Log("score:" + score);
        onSendTotal?.Invoke(score);
    }

    public void setIsNext(float multiplier)
    {
        isNext = true;
        nextMultiplier = multiplier;
        onIsNext?.Invoke(isNext);
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
