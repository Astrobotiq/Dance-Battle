using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/CrowdEffectingEffect")]
public class CrowdEffectingEffect : _Effect
{
    private CrowdManager crowdManager;
    public int expectationIncreaseOrDecreaseValue;
    public override void PlayEffect()
    {
        GameObject crowdManagerGO = GameObject.FindWithTag("CrowdManager");
        crowdManager = crowdManagerGO.GetComponent<CrowdManager>();
        crowdManager.setExpectationPoint(crowdManager.getExpectationPoint()+expectationIncreaseOrDecreaseValue);
    }
}
