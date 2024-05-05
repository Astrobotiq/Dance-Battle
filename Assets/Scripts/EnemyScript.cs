using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    //hem normal hem de powerfull listeleri tekte dondurmek istersek diye bir tane de mainList var
    private List<List<List<CardInfo>>> mainList = new List<List<List<CardInfo>>>(); 
    public List<List<CardInfo>> normalCards = new List<List<CardInfo>>();
    public List<List<CardInfo>> powerfulCards = new List<List<CardInfo>>();
    public List<CardInfo> normalIntroductionCards = new List<CardInfo>();
    public List<CardInfo> normalDevelopmentCards = new List<CardInfo>();
    public List<CardInfo> normalConclusionCards = new List<CardInfo>();
    public List<CardInfo> powerfulIntroductionCards = new List<CardInfo>();
    public List<CardInfo> powerfulDevelopmentCards = new List<CardInfo>();
    public List<CardInfo> powerfulConclusionCards = new List<CardInfo>();
    public List<CardInfo> cardWillBePlayed = new List<CardInfo>();
    //public GameObject scoreKeeperComponent;  score datasinin cekılecegı component
    private float score;

    public void Awake()
    {
        setLists();
    }
    
    private void OnEnable()
    {
        EnemyTurnState.onEnemyTurnStart += chooseCards;
        EnemyTurnState.onEnemyTurnStart += playSelectedCards;
    }

    private void OnDisable()
    {
        EnemyTurnState.onEnemyTurnEnd -= chooseCards;
        EnemyTurnState.onEnemyTurnEnd -= playSelectedCards;
    }

    public void Update()
    {
        //score = scoreKeeperComponent.getScore();
    }

    public void chooseCards()
    {
        //score tutan scripten score'un değerini al ve buradaki score float değerini ona eşitlesin
        //score = scoreKeeperGameobject.GetComponent<>().getScore();
        if (score <= 20)
        {
            cardWillBePlayed.Add(randomCardSelecter(normalCards[0]));
            cardWillBePlayed.Add(randomCardSelecter(normalCards[1]));
            cardWillBePlayed.Add(randomCardSelecter(normalCards[2]));
        }

        if (score<=40)
        {
            cardWillBePlayed.Add(randomCardSelecter(normalCards[0]));
            cardWillBePlayed.Add(randomCardSelecter(normalCards[1]));
            cardWillBePlayed.Add(randomCardSelecter(powerfulCards[2]));
        }

        if (score<=60)
        {
            cardWillBePlayed.Add(randomCardSelecter(normalCards[0]));
            cardWillBePlayed.Add(randomCardSelecter(powerfulCards[1]));
            cardWillBePlayed.Add(randomCardSelecter(powerfulCards[2]));
        }

        if (score<=80)
        {
            cardWillBePlayed.Add(randomCardSelecter(powerfulCards[0]));
            cardWillBePlayed.Add(randomCardSelecter(powerfulCards[1]));
            cardWillBePlayed.Add(randomCardSelecter(powerfulCards[2]));
        }
    }
    
    public void setLists()
    {
        normalCards.Add(normalIntroductionCards);
        normalCards.Add(normalDevelopmentCards);
        normalCards.Add(normalConclusionCards);
        
        powerfulCards.Add(powerfulIntroductionCards);
        powerfulCards.Add(powerfulDevelopmentCards);
        powerfulCards.Add(powerfulConclusionCards);
        
        mainList.Add(normalCards);
        mainList.Add(powerfulCards);
    }

    public CardInfo randomCardSelecter(List<CardInfo> parameterList)
    {
        //min inclusive but max exclusive that way it looks like this
        int randomNum = Random.Range(0, parameterList.Count); 
        return parameterList[randomNum];
    }
    
    //DİKKAT bunu tamamlamayi unutma
    public void playSelectedCards()
    {
        foreach (CardInfo card in cardWillBePlayed)
        {
            //burada seçili kartların CardInfo'ları, score ve effeck olayları için gerekli yere yollanacak
        }
    }
}
