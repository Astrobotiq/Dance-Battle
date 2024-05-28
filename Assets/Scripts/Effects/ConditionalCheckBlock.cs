using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/Conditional /Check Block")]
public class ConditionalCheckBlock : _Effect
{
    public int block;
    public _Effect effect;
    public override void PlayEffect()
    {
        GameObject go = GameObject.FindWithTag("GameBrain");
        GameBrain gb = go.GetComponent<GameBrain>();
        if (gb != null)
        {
            List<_Effect> nextTurnEf = gb.GetEffects(1);
            bool isBig = isBiggerBlock(nextTurnEf);
            if (isBig)
            {
                effect.PlayEffect();
            }
        }
    }

    private bool isBiggerBlock(List<_Effect> effects)
    {
        int blockValue = 0;
        foreach(var effect in effects)
        {
            if (effect.type.Equals(EffectType.BLCK))
            {
                blockValue = effect.getMultiplier();
            }
        }
        if (block < blockValue)
        {
            return true;
        }
        return false;
    }
}
