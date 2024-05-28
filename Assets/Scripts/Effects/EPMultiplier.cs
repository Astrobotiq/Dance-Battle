using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/EP Multiplier")]
public class EPMultiplier : _Effect
{
    public float multiplier;
    public override void PlayEffect()
    {
        GameObject go = GameObject.FindWithTag("CrowdManager");
        CrowdManager cm = go.GetComponent<CrowdManager>();
        if (cm != null)
        {

        }
    }
}
