using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Card", menuName ="Cards")]
public class CardInfo : ScriptableObject
{
    public string CardName;
    public string CardType;
    public string description;
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
        return effect;
    }

    public CardStructure GetCardStructure()
    {
        return cardStructure;
    }
}

public enum CardStructure
{
    Turn, Instant
}
