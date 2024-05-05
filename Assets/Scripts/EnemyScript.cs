using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    private List<List<CardInfo>> mainList = new List<List<CardInfo>>();
    public List<List<CardInfo>> normalCards = new List<List<CardInfo>>();
    public List<List<CardInfo>> powerfulCards = new List<List<CardInfo>>();
    public List<CardInfo> normalIntroductionCards = new List<CardInfo>();
    public List<CardInfo> normalDevelopmentCards = new List<CardInfo>();
    public List<CardInfo> normalConclusionCards = new List<CardInfo>();
    public List<CardInfo> playCards = new List<CardInfo>();
    public GameObject scoreKeeperGameobject;
    private float score;
    

    public void chooseCards()
    {
        //score tutan scripten score'un değerini al ve buradaki score float değerini ona eşitlesin
        //score = scoreKeeperGameobject.GetComponent<>().getScore();
        int randomNum;
        if (score <= 60)
        {
            for (int i = 0; i < 3; )
            {
                while (true)
                {
                    randomNum = Random.Range(1, normalCards.Count-1);
                    CardInfo tempCardInfo = normalCards[randomNum];
                    if (tempCardInfo.cardStructure == CardStructure.Introduction)
                    {
                        i++;
                        break;
                    }
                }

                while (true)
                {
                    
                }
                
                
                playCards.Add(normalCards[randomNum]);
            }
        }
    }
    
    public void get
}
