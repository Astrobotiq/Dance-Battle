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
    [SerializeField] private int score;

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
        if (isAll)
        {
            score = (int)(score * allMultiplier);
            isAll = false;
            allMultiplier = 1;
        }
        Debug.Log("score:" + score);
        scoreList.Add(score);
        onSendTotal?.Invoke(score);
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

    private void OnEnable()
    {
        CrowdTurnState.onCrowdEnter += sendTotalPoint;
    }

    private void OnDisable()
    {
        CrowdTurnState.onCrowdEnter -= sendTotalPoint;
    }

}
