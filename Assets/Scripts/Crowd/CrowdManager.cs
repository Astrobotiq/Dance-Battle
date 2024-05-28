using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CrowdManager : MonoBehaviour
{
    int expectationPoint;
    int tempExpectationPoint;
    public List<Crowd> crowds;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioClip bored;
    [SerializeField] private AudioClip exited;

    private void Awake()
    {
        expectationPoint = 10;
        tempExpectationPoint = expectationPoint;
    }

    public int calculatePoint(int score, int expectation)//This function calculate next Turn expectation point according to last point.
    {
        var tempScore = score - expectation;
        if (tempScore > expectation)
        {
            tempScore = expectation;
        }
        if (tempScore + expectation<0)
        {
            tempScore = 0;
        }
        return expectation + tempScore;
    }

    public void handleExpectation(int score) //This function take total score made in a turn and change the crowd behavior.
    {
        if (score < tempExpectationPoint)
        {
            //You are failure
            foreach (var crowd in crowds)
            {
                crowd.getBored();
                soundManager.crowdSoundEffectCall(bored);
            }
        }
        else if (score > tempExpectationPoint)
        {
            //You are successfull
            foreach (var crowd in crowds)
            {
                crowd.getExited();
                soundManager.crowdSoundEffectCall(exited);
            }
        }
        expectationPoint = calculatePoint(score, tempExpectationPoint);
        tempExpectationPoint = expectationPoint;
    }

    public int getExpectationPoint()
    {
        return tempExpectationPoint;
    }

    public void setExpectationPoint(int point) // this function can be used in a card. For example:
    {                                          // crowdManager.setExpectationPoint(crowdManager.getExpectationPoint()+10)
        tempExpectationPoint = point;
    }

    public void setMultiplier(float value)
    {
        tempExpectationPoint = (int)(tempExpectationPoint* value);
    }

    private void OnEnable()
    {
        ScoreManager.onSendTotal += handleExpectation;
    }

}
