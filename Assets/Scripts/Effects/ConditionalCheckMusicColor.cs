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
        if(go == null)
        {
            Debug.Log("Sound Manager go bulunamadý");
        }
        SoundManager sm = go.GetComponent<SoundManager>();
        if(sm == null)
        {
            Debug.Log("Sound Manager bulunamadý");
        }
        if (sm != null)
        {
            Debug.Log(musicColor.Equals(sm.getMusicColor())?"music color eþleþti":"music color eþleþmedi");
            if (sm.getMusicColor().Equals(musicColor))
            {
                effect.PlayEffect();
            }
        }
    }
}
