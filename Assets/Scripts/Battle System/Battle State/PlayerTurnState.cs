using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : BattleState
{

    public static event StateAction onPlayerTurnStart;
    public static event StateAction onPlayerTurnEnd;
    
    public bool isSkipping = false;
    public override void EnterState()
    {
        Debug.Log("Player�n turn'� �imdi");
        if (isSkipping)
        {
            isSkipping = false;
            ExitState();
        }
        else
        {
            onPlayerTurnStart?.Invoke();
        }
            //UI'da player turn yazar
            //���klar player'a d�ner
            //Ekrandaki 3 kart oynama noktas� aktive olur
            //player kart oynayana kadar ge�me
            //player butona bas�nca animasyon oynar
            //animasyon bitince seyirci state'ine ge�er
    }

    public override void ExitState()
    {
        GameObject cardBox = GameObject.FindWithTag("PlayArea");
        PlayAreaHandler playArea = cardBox.GetComponent<PlayAreaHandler>();
        if (playArea != null)
        {
            playArea.disablePlayerTurnCardArea();
        }
        onPlayerTurnEnd?.Invoke();
    }

    public override void updateState()
    {
        
    }

    public void setIsSkippingTrue()
    {
        isSkipping = true;
    }
}
