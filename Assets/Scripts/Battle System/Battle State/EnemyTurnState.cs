using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : BattleState
{
    public static event StateAction onEnemyTurnStart;
    public static event StateAction onEnemyTurnEnd;
    public static event UIAction onUIOpened;
    public static event UIAction onUIClosed;

    public bool isSkipping = false;
    public override void EnterState()
    {
        Debug.Log("Enemy Turn Ba�lad�. Hurraa");
        onUIOpened?.Invoke("ENEMY");
        StartCoroutine(enterStateDelay());
    }

    public override void ExitState()
    {
        if (onEnemyTurnEnd != null)
        {
            onEnemyTurnEnd?.Invoke();
        }
    }

    public override void updateState()
    {
        throw new System.NotImplementedException();
    }

    public void setIsSkippingTrue()
    {
        isSkipping = true;
    }

    IEnumerator enterStateDelay()
    {
        yield return new WaitForSeconds(2);
        onUIClosed?.Invoke("ENEMY");
        if (isSkipping)
        {
            isSkipping = false;
            ExitState();
        }
        else
        {
            onEnemyTurnStart?.Invoke();
        }
    }
}
