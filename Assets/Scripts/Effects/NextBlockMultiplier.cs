using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/Next Divider Multiplier")]
public class NextBlockMultiplier : _Effect
{
    public float multiplier;
    public override void PlayEffect()
    {
        GameObject go = GameObject.FindWithTag("Score Manager");
        ScoreManager sm = go.GetComponent<ScoreManager>();
        if (sm != null)
        {
            sm.setIsNextDivide(multiplier);
        }
    }
}
