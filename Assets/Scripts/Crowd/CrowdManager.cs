using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManager : MonoBehaviour
{
    int expectationPoint;
    public List<Crowd> crowds;
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
        if (score < expectationPoint)
        {
            //You are failure
            foreach (var crowd in crowds)
            {
                crowd.getBored();
            }
        }
        else if (score > expectationPoint)
        {
            //You are successfull
            foreach (var crowd in crowds)
            {
                crowd.getExited();
            }
        }
        expectationPoint = calculatePoint(score, expectationPoint);
    }

    public int getExpectationPoint()
    {
        return expectationPoint;
    }

    public void setExpectationPoint(int point) // this function can be used in a card. For example:
    {                                          // crowdManager.setExpectationPoint(crowdManager.getExpectationPoint()+10)
        expectationPoint = point;
    }

    private void OnEnable()
    {
        ScoreManager.onSendTotal += handleExpectation;
    }

}
