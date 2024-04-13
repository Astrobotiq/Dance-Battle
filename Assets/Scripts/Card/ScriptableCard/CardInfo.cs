using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Card", menuName ="Cards")]
public class CardInfo : ScriptableObject
{
    public string CardName;
    public string CardType;
    public AnimationClip animation;
    //Effect effect; this will be implemented
    // Start is called before the first frame update
    
}
