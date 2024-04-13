using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    //public EffectClass effect;        Effect class eklenince commentden çıkarırız
    private CardInfo cardInfo;
    public Boolean isInBox = false; // kutu içinde dışında kontrol edip general ınput yollamak için
    public GameObject forBox; // collide eden kutunun referansını yollamak için
    public CardInfoDisplayer cardDisplayer;

    public void Animate(){ } //şuanlık boş gerekince doldur

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CardBox")
        {
            isInBox = true;
            forBox = other.gameObject;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        isInBox = false;
    }

    public void setCardInfo(CardInfo card)
    {
        
        cardInfo= card;

        cardDisplayer.display(cardInfo.CardName, cardInfo.CardType);
        
    }

    public CardInfo GetCardInfo()
    {
        return cardInfo;
    }

    

    

    //tamamlanacak
}
