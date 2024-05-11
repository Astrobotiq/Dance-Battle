using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/Score Multiplier Effect")]
public class Multiply_DamageEffect : _Effect
{
    private ScoreManager scoreManager;
    public float multiplyAmount;
    

    public override void PlayEffect()
    {
        GameObject temp = GameObject.FindWithTag("ScoreManager");
        scoreManager = temp.GetComponent<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.setIsNext(multiplyAmount);
        }
    }
}
