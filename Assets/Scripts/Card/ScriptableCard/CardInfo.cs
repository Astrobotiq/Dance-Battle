using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Card", menuName ="Cards")]
public class CardInfo : ScriptableObject
{
    public string CardName;
    public string CardType;
    [SerializeField]
    private AnimationClip animation;
    [SerializeField]
    private List<_Effect> effect;

    

    public CardStructure cardStructure;

    public AnimationClip getAnimation()
    {
        return animation;
    }

    public List<_Effect> getEffect()
    {
        Debug.Log("from card info " + effect.Count + " " + CardName); 
        return effect;
    }
}

public enum CardStructure
{
    Introduction, Development, Conclusion, Instant
}
