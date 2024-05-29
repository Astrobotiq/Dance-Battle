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
    private bool isNextDivide;
    private bool isAll;
    private float nextMultiplier;
    private float nextDivider;
    private float allMultiplier;
    [SerializeField] private int score;
    GameBrain gameBrain;

    public delegate void isNextPlayed(bool isNext);
    public static event isNextPlayed onIsNext;
    public static event Action<int> onSendTotal;

    // Start is called before the first frame update
    void Start()
    {
        GameObject brainObject = GameObject.FindWithTag("GameBrain");
        gameBrain = brainObject.GetComponent<GameBrain>();
        nextMultiplier = 1;
        allMultiplier = 1;
        nextDivider = 1;
        isNextDivide = false;
        isNext = false; isAll = false;
    }

    public void Awake()
    {
        scoreList = new List<int>();
    }

    public void addToScore(int point)
    {
        if(point<0)
        {
            if (isNextDivide)
            {
                point = (int)(point * nextDivider);
                nextDivider = 1;
                isNextDivide = false;
            }
        }
        else if (point>0)
        {
            if (isNext)
            {
                point = (int)(point * nextMultiplier);
                nextMultiplier = 1;
                isNext = false;
                onIsNext?.Invoke(isNext);
            }
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
        bool AllPurple = isAllPurple();
        Debug.Log(AllPurple ? "All purple" : "Not Purple");
        Debug.Log("score:" + score);
        if (AllPurple)
        {
            score = (int)(score * 1.25);
            Debug.Log("score after AllPurple:" + score);
        }
        scoreList.Add(score);
        onSendTotal?.Invoke(score); 
        score = 0;
    }

    public bool isAllPurple()
    {
        List<CardColor> cardColors = gameBrain.GetCardColors();
        foreach (CardColor color in cardColors)
        {
            if (!color.Equals(CardColor.PURPLE))
            {
                return false;
            }
        }
        return true;
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

    public void setIsNextDivide(float divider)
    {
        isNextDivide = true;
        nextDivider = divider;
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

    public void onWin()
    {
        nextMultiplier = 1;
        allMultiplier = 1;
        nextDivider = 1;
        isNextDivide = false;
        isNext = false; isAll = false;
    }

    private void OnEnable()
    {
        CrowdTurnState.onCrowdEnter += sendTotalPoint;
        UIManager.onWin += onWin;
    }

    private void OnDisable()
    {
        CrowdTurnState.onCrowdEnter -= sendTotalPoint;
        UIManager.onWin -= onWin;
    }
    

}
