using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    //hem normal hem de powerfull listeleri tekte dondurmek istersek diye bir tane de mainList var
    /*private List<List<List<CardInfo>>> mainList = new List<List<List<CardInfo>>>(); 
    public List<List<CardInfo>> normalCards = new List<List<CardInfo>>();
    public List<List<CardInfo>> powerfulCards = new List<List<CardInfo>>();
    public List<CardInfo> normalIntroductionCards = new List<CardInfo>();
    public List<CardInfo> normalDevelopmentCards = new List<CardInfo>();
    public List<CardInfo> normalConclusionCards = new List<CardInfo>();
    public List<CardInfo> powerfulIntroductionCards = new List<CardInfo>();
    public List<CardInfo> powerfulDevelopmentCards = new List<CardInfo>();
    public List<CardInfo> powerfulConclusionCards = new List<CardInfo>();*/
    public List<CardInfo> cardWillBePlayed = new List<CardInfo>();

    public List<CardInfo> cards;

    [SerializeField] private GameBrain gameBrain;
    [SerializeField] private AnimationHandler animationHandler;
    [SerializeField] private ScoreManager scoreManager;


    public List<Card> cardss; 
    
    private float score;

    public void Awake()
    {
        //setLists();
    }
    
    private void OnEnable()
    {
        SpecialTurn.onEnterSpecial += chooseCards;
        EnemyTurnState.onEnemyTurnStart += sendSelectedCards;
    }

    private void OnDisable()
    {
        SpecialTurn.onEnterSpecial -= chooseCards;
        EnemyTurnState.onEnemyTurnEnd -= sendSelectedCards;
    }

    public void chooseCards()
    {
        cardWillBePlayed = new List<CardInfo>();
        cardWillBePlayed.Add(randomCardSelecter(cards));
        cardWillBePlayed.Add(randomCardSelecter(cards));
        cardWillBePlayed.Add(randomCardSelecter(cards));
        disPlayCards();
    }

    /*public void chooseCards()
    {
        //score tutan scripten score'un değerini al ve buradaki score float değerini ona eşitlesin
        //score = scoreKeeperGameobject.GetComponent<>().getScore();
        Debug.Log("Chose Card is Entered");
        score = scoreManager.getLastListIndex();
        if (score <= 20)
        {
            cardWillBePlayed.Add(randomCardSelecter(normalCards[0]));
            cardWillBePlayed.Add(randomCardSelecter(normalCards[1]));
            cardWillBePlayed.Add(randomCardSelecter(normalCards[2]));
        }

        else if (score<=40)
        {
            cardWillBePlayed.Add(randomCardSelecter(normalCards[0]));
            cardWillBePlayed.Add(randomCardSelecter(normalCards[1]));
            cardWillBePlayed.Add(randomCardSelecter(powerfulCards[2]));
        }

        else if (score<=60)
        {
            cardWillBePlayed.Add(randomCardSelecter(normalCards[0]));
            cardWillBePlayed.Add(randomCardSelecter(powerfulCards[1]));
            cardWillBePlayed.Add(randomCardSelecter(powerfulCards[2]));
        }

        else if (score<=80)
        {
            cardWillBePlayed.Add(randomCardSelecter(powerfulCards[0]));
            cardWillBePlayed.Add(randomCardSelecter(powerfulCards[1]));
            cardWillBePlayed.Add(randomCardSelecter(powerfulCards[2]));
        }

        disPlayCards();
        //sendSelectedCards();
    }*/

    private void disPlayCards()
    {
       for (int i = 0; i < cardWillBePlayed.Count; i++)
        {
            cardss[i].setCardInfo(cardWillBePlayed[i]);
        }
    }

    public CardInfo randomCardSelecter(List<CardInfo> parameterList)
    {
        //min inclusive but max exclusive that way it looks like this
        int randomNum = Random.Range(0, parameterList.Count); 
        return parameterList[randomNum];
    }
    
    //DİKKAT bunu tamamlamayi unutma
    public void sendSelectedCards()
    {
        List<AnimationClip> animationClips = new List<AnimationClip>();
        List<List<_Effect>> effects = new List<List<_Effect>>();
        
        foreach (CardInfo cardInfo in cardWillBePlayed)
        {
            effects.Add(cardInfo.getEffect());
            animationClips.Add(cardInfo.getAnimation());
        }
        
        animationHandler.addAnimation(animationClips);
        gameBrain.addEffects(effects);
    }
    
   /* public void setLists()
    {
        normalCards.Add(normalIntroductionCards);
        normalCards.Add(normalDevelopmentCards);
        normalCards.Add(normalConclusionCards);
        
        powerfulCards.Add(powerfulIntroductionCards);
        powerfulCards.Add(powerfulDevelopmentCards);
        powerfulCards.Add(powerfulConclusionCards);
        
        mainList.Add(normalCards);
        mainList.Add(powerfulCards);
    }*/
}
