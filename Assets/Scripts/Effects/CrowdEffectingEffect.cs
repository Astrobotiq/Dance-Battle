using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/CrowdEffectingEffect")]
public class CrowdEffectingEffect : _Effect
{
    public GameObject crowdManagerGameObject;
    private CrowdManager crowdManagerReference;
    public int expectationIncreaseOrDecreaseValue;
    public override void PlayEffect()
    {
        crowdManagerGameObject = GameObject.Find("CrowdManager");
        crowdManagerReference = crowdManagerGameObject.GetComponent<CrowdManager>();
        crowdManagerReference.setExpectationPoint(crowdManagerReference.getExpectationPoint()+expectationIncreaseOrDecreaseValue);
    }
}
