using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/Conditional /Check DMG")]
public class ConditionalCheckDMG : _Effect
{
    public int dmg;
    public _Effect effect;
    public override void PlayEffect()
    {
        GameObject go = GameObject.FindWithTag("GameBrain");
        GameBrain gb = go.GetComponent<GameBrain>();
        if (gb != null)
        {
            List<_Effect> thisTurnEf = gb.GetEffects(0);
            bool isBig = isBiggerDamage(thisTurnEf);
            if (isBig)
            {
                effect.PlayEffect();
            }
        }
    }

    private bool isBiggerDamage(List<_Effect> effects)
    {
        int damageValue = 0;
        foreach (var effect in effects)
        {
            if (effect.type.Equals(EffectType.DMG))
            {
                damageValue = effect.getMultiplier();
            }
        }
        if (dmg > damageValue)
        {
            return true;
        }
        return false;
    }
}
