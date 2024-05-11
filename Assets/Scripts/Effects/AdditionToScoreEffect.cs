using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/Score Effect")]
public class AdditionToScoreEffect : _Effect
{
    private ScoreManager scoreManager;
    public int additionAmount;
    
    public override void PlayEffect()
    {
        GameObject temp = GameObject.FindWithTag("ScoreManager");
        scoreManager = temp.GetComponent<ScoreManager>();
        if (scoreManager != null )
        {
            scoreManager.addToScore(additionAmount);
        }
        
    }
}
