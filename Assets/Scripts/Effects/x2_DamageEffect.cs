using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x2_DamageEffect : _Effect
{
    x2_DamageEffect()
    {
        description = "Multiply damage by 2";
        crowdPoint = 1f;
        crowdMultiplier = 2f;
        type = "Multiplier";
    }
}
