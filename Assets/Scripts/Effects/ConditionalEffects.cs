using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            List<CardColor> colors = new List<CardColor>();
            colors.Add(gb.GetCardColors(0));
            colors.Add(gb.GetCardColors(1));
            colors.Add(gb.GetCardColors(2));

            bool isMatched = compareCardCol(checkColor, colors);
            if (isMatched)
            {
                gb.addEffect(effect);
                Debug.Log("Effect added to gamebrain from conditional Card");
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
