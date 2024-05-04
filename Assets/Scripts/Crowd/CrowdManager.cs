using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManager : MonoBehaviour
{
    int expectationPoint;
    public int calculatePoint(int score, int expectation)
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

    public void handleExpectation(int score)
    {
        if (score < expectationPoint)
        {
            //You are done failed
        }
        else if (score > expectationPoint)
        {
            //You are successed
        }
        else
        {
            //You are done nothing
        }
        expectationPoint = calculatePoint(score, expectationPoint);
    }

    public int getExpectationPoint()
    {
        return expectationPoint;
    }
    
}
