using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/Conditional /Check Music Color")]
public class ConditionalCheckMusicColor : _Effect
{
    public CardColor musicColor;
    public _Effect effect;
    public override void PlayEffect()
    {
        GameObject go = GameObject.FindWithTag("SoundManager");
        SoundManager sm = go.GetComponent<SoundManager>();
        if (sm != null)
        {
            if (sm.getMusicColor().Equals(musicColor))
            {
                effect.PlayEffect();
            }
        }
    }
}
