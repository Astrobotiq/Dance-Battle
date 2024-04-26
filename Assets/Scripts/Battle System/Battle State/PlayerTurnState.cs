using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : BattleState
{

    public static event StateAction onPlayerTurnStart;
    public static event StateAction onPlayerTurnEnd;
    public override void EnterState()
    {
        
            onPlayerTurnStart?.Invoke();
            //UI'da player turn yazar
            //ýþýklar player'a döner
            //Ekrandaki 3 kart oynama noktasý aktive olur
            //player kart oynayana kadar geçme
            //player butona basýnca animasyon oynar
            //animasyon bitince seyirci state'ine geçer
    }

    public override void ExitState()
    {   
       
         onPlayerTurnEnd?.Invoke();
        
    }

    public override void updateState()
    {
        
    }

    
}
