using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private BattleSystem battleSystem;
    [SerializeField] private CrowdManager crowdManager;
    [SerializeField] private GameBrain GameBrainRef;

    

    public bool enteredToSliderUp;
    public bool enteredToSliderDown;
    //[SerializeField] private AnimationHandler enemyAnimationHandler; sonradan enemynin ne oynadığını gösterirsek diye koydum

    public TextMeshProUGUI scoreTextBox;
    public TextMeshProUGUI turnTextBox;
    public TextMeshProUGUI expectationTextBox;
    public Slider slider;

    public delegate void UIEvents();
    //this will be using when color change card played
    public static event UIEvents onColorChangerActivate;
    public static event UIEvents onColorChangerDeactivate;
    public static event UIEvents onWin;
    public static event UIEvents onLose;
    public GameObject colorChange;

    //Win Card Selection
    public List<TextMeshProUGUI> cardInfos;
    [SerializeField] private CardBaseHolder cardBaseHolder;
    [SerializeField] private ShuffleHolder shuffleHolder;
    private List<CardInfo> cardsToSelect;
    public GameObject cardSelectionUI;

    private void Awake()
    {
        enteredToSliderUp = true;
        enteredToSliderDown = true;
    }

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
            if (GameBrainRef.getCurrentTurn()%2==0 && enteredToSliderUp)
            {
                
                enteredToSliderUp = false;
                enteredToSliderDown = true;
                float temp = slider.value;
                slider.value = temp + scoreManager.getLastListIndex(); 
            }
            else if (GameBrainRef.getCurrentTurn()%2==1 && enteredToSliderDown)
            {
                
                enteredToSliderDown = false;
                enteredToSliderUp = true;
                float temp = slider.value;
                slider.value = temp - scoreManager.getLastListIndex();
            }
            if (GameBrainRef.winPoint < slider.value)
            {
                Debug.Log("I winn");
                onWin?.Invoke();
                slider.value = 50;
                //Open win window
            }else if (GameBrainRef.LosePoint > slider.value)
            {
                onLose?.Invoke();
            }
            else
            {
                GameBrainRef.setBattleState();
            }
            
            if (slider.value > 100)
            {
                slider.value = 100;
            }
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
        expectationTextBox.text = ("Expectation: " + crowdManager.getExpectationPoint());
    }

    public void updateUI()
    {
        setTheTurnText();
        setExpectationTextBox();
    }

    public void openFetchCards()
    {
        Debug.Log("Card will be select");
        cardsToSelect = new List<CardInfo> ();
        for(int i = 0; i<3; i++)
        {
            cardsToSelect.Add(cardBaseHolder.Draw());
        }
        Debug.Log("Cards selected");
        int index = 0;
        foreach(CardInfo cardInfo in cardsToSelect)
        {
            cardInfos[index++].text = "Name: " + cardInfo.name;
            cardInfos[index++].text = "Description: " + cardInfo.description;
        }
        Debug.Log("Cards displayed");
        cardSelectionUI.SetActive(true);
        GameBrainRef.stopGame();
    }

    public void sendCards(int index)
    {
        cardSelectionUI.SetActive(false);
        shuffleHolder.Add(cardsToSelect[index]);
    }

    private void OnEnable()
    {
        WinState.onEnter += openFetchCards;
        CrowdTurnState.onCrowdExit += setTheScoreText;
    }

    private void OnDisable()
    {
        WinState.onEnter -= openFetchCards;
        CrowdTurnState.onCrowdExit -= setTheScoreText;
    }
}
