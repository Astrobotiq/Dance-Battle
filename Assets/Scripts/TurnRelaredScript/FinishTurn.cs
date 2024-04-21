using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinishTurn : MonoBehaviour
{
    [SerializeField] private List<GameObject> cardBoxes;
    [SerializeField] private GameObject refCardHolder;
    [SerializeField] private GameObject refHandHolder;

    private Boolean isAllFilled = true;
    // Start is called before the first frame update
    
    //silinecek effect calisma test etmek icin ekledim
    public GameObject sonradanSil;
    public void Start()
    {
        if (refCardHolder == null)
        {
            refCardHolder = GameObject.Find("CardHolder");
        }
    }

    public void Update()
    {
        isAllFilled = true;
        foreach (var cardBox in cardBoxes)
        {
            if (cardBox.GetComponent<CardBoxOnScreen>().getTheCardInBox() == null)
            {
                isAllFilled = false;
            }
        }
    }

    public void FinishPlayerTurn()
    {
        if (isAllFilled)
        {
            foreach (var cardBox in cardBoxes)
            {
                GameObject tempCard = cardBox.GetComponent<CardBoxOnScreen>().getTheCardInBox();
                //Debug.Log(tempCard.name);
                refCardHolder.GetComponent<DiscardHolder>().Add(tempCard.GetComponent<Card>().GetCardInfo());
                
                //ONEMLI
                //alinan refHandHolder objesinin icindeki HandHolder scripte bakip oradan da kari silmesi lazim
                
                sonradanSil.GetComponent<ForCheckEffects>().AddToCards(tempCard.GetComponent<Card>().GetCardInfo());
                Destroy(tempCard);
                //şuan boş anımate functıon içi ondan şimdilik adını çıkarıyor debug ekranına
                //cardBox.GetComponent<CardBoxOnScreen>().getTheCardInBox().GetComponent<Card>().Animate();
            }
            sonradanSil.GetComponent<ForCheckEffects>().PlayStoredEffects();
        }
        else
        {
            Debug.Log("Fill the boxes, now they are not full");
        }
    }
}
