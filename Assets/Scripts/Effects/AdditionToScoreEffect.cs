using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/Score Effect")]
public class AdditionToScoreEffect : _Effect
{
    [SerializeField] private GameObject ScoreLogic;
    public int additionAmount;
    
    public override void PlayEffect()
    {
        
        //theMainScoreLogicGameObject.gameObject.GetComponent<>()
        /*
        var component_ref = theMainScoreLogicGameObject.GetComponent<Score>();
        float temp = component_ref.getScore();
        component_ref.setScore(temp + crowdPoint);
        */
    }
}
