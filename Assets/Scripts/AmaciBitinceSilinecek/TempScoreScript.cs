using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TempScoreScript : MonoBehaviour
{
    public Image UI_score;
    public float score;
    public float maxScore;
    
    
    // Start is called before the first frame update
    public void Update()
    {
        UIScoreUpdate();

        if (score >= maxScore)
        {
            score = maxScore;
        }
    }

    // Update is called once per frame
    public void scoreDecrease()
    {
        score -= 10;
    }

    public void UIScoreUpdate()
    {
        Color color = Color.Lerp(Color.red, Color.green, (score / maxScore));
        UI_score.color = color;
    }
}
