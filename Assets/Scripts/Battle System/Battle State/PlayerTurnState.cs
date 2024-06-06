using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : BattleState
{

    public static event StateAction onPlayerTurnStart;
    public static event StateAction onPlayerTurnEnd;
    public static event UIAction onUIOpened;
    public static event UIAction onUIClosed;

    public bool isSkipping = false;
    public override void EnterState()
    {
        Debug.Log("Player�n turn'� �imdi");
        onUIOpened?.Invoke("PLAYER");
        StartCoroutine(enterStateDelay());
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

    IEnumerator enterStateDelay()
    {
        yield return new WaitForSeconds(2);
        onUIClosed?.Invoke("CROWD");
        if (isSkipping)
        {
            isSkipping = false;
            ExitState();
        }
        else
        {
            onPlayerTurnStart?.Invoke();
        }
    }

}
