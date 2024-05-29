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
    public TooltipTrigger sliderTrigger; 

    public delegate void UIEvents();
    public delegate void ColorChange(int index);
    //this will be using when color change card played
    public static event ColorChange onColorChangerActivate;
    public static event ColorChange onColorChangerDeactivate;
    public static event UIEvents onWin;
    public static event UIEvents onLose;
    public GameObject colorChange;

    //Win Card Selection
    public List<TextMeshProUGUI> cardInfos;
    [SerializeField] private CardBaseHolder cardBaseHolder;
    [SerializeField] private ShuffleHolder shuffleHolder;
    private List<CardInfo> cardsToSelect;
    public GameObject cardSelectionUI;

    public SceneLoader sceneLoader;
    public GameObject winPanel;
    public GameObject losePanel;

    private void Awake()
    {
        enteredToSliderUp = true;
        enteredToSliderDown = true;
        Debug.Log("Slider " + slider.value.ToString());
        string s = slider.value.ToString();
        Debug.Log(s);
        sliderTrigger.display( "EP", s);
    }

    public void activateColorChanger()
    {
        colorChange.SetActive(true);
        //onColorChangerActivate?.Invoke(); // yakalayan scriptleri yaz. Mesela gameBrain oyunu durdursun. ses efekti oynansın. 
        
    }

    public void deactivateColorChanger(int index)
    {
        colorChange.SetActive(false);
        onColorChangerDeactivate?.Invoke(index);// yakalayan scriptleri yaz. Mesela gameBrain oyunu devam ettirsin. ses efekti oynansın. 
        
    }

    public void setTheScoreText()
    {
        if (!scoreManager.isScoreListEmpty())
        {
            Debug.Log("Curretn Turn :" + GameBrainRef.getCurrentTurn());
            Debug.Log("enter to slider up : " + enteredToSliderUp);
            Debug.Log("enter to slider down : " + enteredToSliderDown);
            if (GameBrainRef.getCurrentTurn()%2==0 && enteredToSliderUp)
            {
                Debug.Log("Slider yukarı gidecek");
                enteredToSliderUp = false;
                enteredToSliderDown = true;
                float temp = slider.value;
                slider.value = temp + scoreManager.getLastListIndex();
                temp = slider.value;
                

            }
            else if (GameBrainRef.getCurrentTurn()%2==1 && enteredToSliderDown)
            {
                Debug.Log("Slider aşağı gidecek");
                enteredToSliderDown = false;
                enteredToSliderUp = true;
                float temp = slider.value;
                slider.value = temp - scoreManager.getLastListIndex();
            }
            Debug.Log("to win " +GameBrainRef.winPoint);
            Debug.Log("current " + slider.value);
            Debug.Log("to lose " + GameBrainRef.LosePoint);
            if (GameBrainRef.winPoint < slider.value)
            {
                //Open win window
                winPanel.SetActive(true);
                StartCoroutine(winDelay());
            }else if (GameBrainRef.LosePoint > slider.value)
            {
                losePanel.SetActive(true);
                StartCoroutine (loseDelay());
                
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
        sliderTrigger.display("" + slider.value.ToString(), null);
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
        GameBrainRef.stopGame(0);
    }

    public void sendCards(int index)
    {
        cardSelectionUI.SetActive(false);
        shuffleHolder.Add(cardsToSelect[index]);
    }

    IEnumerator winDelay()
    {
        yield return new WaitForSeconds(3);
        winPanel.SetActive(false);
        Debug.Log("I winn");
        onWin?.Invoke();
        slider.value = 50;
    }

    IEnumerator loseDelay()
    {
        yield return new WaitForSeconds(3);
        losePanel.SetActive(false);
        sceneLoader.changeScene(0);
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
