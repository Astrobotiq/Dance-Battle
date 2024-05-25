using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private BattleSystem battleSystem;
    [SerializeField] private CrowdManager crowdManager;
    //[SerializeField] private AnimationHandler enemyAnimationHandler; sonradan enemynin ne oynadığını gösterirsek diye koydum

    public TextMeshProUGUI scoreTextBox;
    public TextMeshProUGUI turnTextBox;
    public TextMeshProUGUI expectationTextBox;

    public delegate void UIEvents();
    //this will be using when color change card played
    public static event UIEvents onColorChangerActivate;
    public static event UIEvents onColorChangerDeactivate;
    public GameObject colorChange;


    public void activateColorChanger()
    {
        colorChange.SetActive(true);
        onColorChangerActivate?.Invoke(); // yakalayan scriptleri yaz. Mesela gameBrain oyunu durdursun. ses efekti oynansın. 
        
    }

    public void deactivateColorChanger()
    {
        colorChange.SetActive(false);
        onColorChangerDeactivate?.Invoke();// yakalayan scriptleri yaz. Mesela gameBrain oyunu devam ettirsin. ses efekti oynansın. 
        
    }
    public void setTheScoreText()
    {
        if (!scoreManager.isScoreListEmpty())
        {
            //Debug.Log(scoreManager.getLastListIndex() + " nasilsin");
            scoreTextBox.text = "Score: " + scoreManager.getLastListIndex();
        }
    }

    public void setTheTurnText()
    {
        BattleState temp_state = battleSystem.getState();
        //Debug.Log("janim " + temp_state.GetType().Name);
        String temp_string = "";

        if (temp_state.GetType().Name=="PlayerTurnState")
        {
            temp_string = "Player's Turn";
        }
        else if (temp_state.GetType().Name == "EnemyTurnState")
        {
            temp_string = "Enemy's Turn";
        }
        else if (temp_state.GetType().Name == "SpecialTurn")
        {
            temp_string = "Special Turn";
        }
        else if(temp_state.GetType().Name=="CrowdTurnState")
        {
            temp_string = "Crowd Reacts";
        }
        else
        {
            temp_string = "";
        }
        turnTextBox.text = "Now " + temp_string;
    }

    public void setExpectationTextBox()
    {
        expectationTextBox.text = ("Expectation is " + crowdManager.getExpectationPoint());
    }

    public void updateUI()
    {
        setTheScoreText();
        setTheTurnText();
        setExpectationTextBox();
    }
}
