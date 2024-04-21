using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenScoreEffect : _Effect
{
    [SerializeField] private GameObject theMainScoreLogicGameObject;
    
    public TenScoreEffect()
    {
        description = "gain 10 crowd point";
        crowdPoint = 10f;
        crowdMultiplier = 1f;
        turnCounter = 0;
    }
    
    public override void PlayEffect()
    {
        /*
        var component_ref = theMainScoreLogicGameObject.GetComponent<Score>();
        float temp = component_ref.getScore();
        component_ref.setScore(temp + crowdPoint);
        */
    }
}
