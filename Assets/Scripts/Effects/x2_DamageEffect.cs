using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x2_DamageEffect : _Effect
{
    [SerializeField] private GameObject theMainScoreLogicGameObject;
    public x2_DamageEffect()
    {
        description = "Multiply damage by 2";
        crowdPoint = 1f;
        crowdMultiplier = 2f;
        turnCounter = 0; //counter sifir iken effect oynatilmasina bakan script logic effecti oynatir.
                         //0 dan farkli ise de bir azaltir ve depolandigi yerde tutar
    }

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
