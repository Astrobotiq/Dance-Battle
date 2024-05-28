using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/Conditional /Check Card Color")]
public class ConditionalEffect : _Effect
{
    public CardColor checkColor;
    public _Effect effect;
    public override void PlayEffect()
    {
        GameObject go = GameObject.FindWithTag("GameBrain");
        GameBrain gb = go.GetComponent<GameBrain>();
        if (gb != null )
        {
            List<CardColor> colors = gb.GetCardColors();

            bool isMatched = compareCardCol(checkColor, colors);
            if (isMatched)
            {
                effect.PlayEffect();
            }
        }
    }


    private bool compareCardCol(CardColor color, List<CardColor> colors) 
    {
        foreach (CardColor c in colors)
        {
            if (!color.Equals(c))
            {
                return false;
            }
        }
        return true;
    }
}
