using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/Conditional /Check EP")]
public class ConditionalCheckEP : _Effect
{
    public int EP;
    public _Effect effect;

    public override void PlayEffect()
    {
        GameObject go = GameObject.FindWithTag("CrowdManager");
        CrowdManager cm = go.GetComponent<CrowdManager>();
        if (cm != null)
        {
            if(cm.getExpectationPoint() < EP)
            {
                effect.PlayEffect();
            }
        }
    }
}
