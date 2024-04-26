using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/Score Multiplier Effect")]
public class Multiply_DamageEffect : _Effect
{
    //[SerializeField] private GameObject theMainScoreLogicGameObject;
    public int damageAmount;
    

    public override void PlayEffect()
    {

        //ornek bir implementasyon
        /*
        var component_ref = theMainScoreLogicGameObject.GetComponent<Score>();
        float temp = component_ref.getScore();
        component_ref.setScore(temp * crowdMultiplier);
        */
    }
}
