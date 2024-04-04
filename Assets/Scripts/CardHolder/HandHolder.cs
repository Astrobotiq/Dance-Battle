using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandHolder : MonoBehaviour
{
    [SerializeField]
    Transform lastCardPos;
    [SerializeField]
    Transform firstCardPos;
    [SerializeField]
    Vector3 scale;
    private int lastIndex;
    List<Card> cards;

    

    // Start is called before the first frame update
    void Start()
    {
        cards = new List<Card>();
        lastIndex = 0;
        scale = new Vector3(0.05f, 1, 0.075f);
    }

    public void Add(Card card)
    {
        cards.Add(card);
        calculatePos();
    }

    public Card Remove(int index)
    {
        Card card = cards[index];
        cards.RemoveAt(index);
        calculatePos() ;
        return card;
    }

    public void calculatePos()
    {
        int cardNum = cards.Count;
        float newPos;
        if (cardNum == 1)
        {
            lastCardPos.position = transform.position;
            firstCardPos.position = transform.position;
            GameObject card = cards[0].gameObject;
            card.GetComponent<CardAnimator>().MoveAndScaleObject(firstCardPos.position, scale);
            lastIndex = cardNum;
        }
        else if(cardNum == 2)
        {

            newPos=findNextPos(lastIndex,cardNum,lastCardPos.position.x,0.2f);
            lastCardPos.position = new Vector3(newPos, transform.position.y,transform.position.z);
            firstCardPos.position = new Vector3(-newPos, transform.position.y, transform.position.z);
            GameObject card = cards[0].gameObject;
            card.GetComponent<CardAnimator>().MoveAndScaleObject(firstCardPos.position, scale);
            GameObject card1 = cards[1].gameObject;
            card1.GetComponent<CardAnimator>().MoveAndScaleObject(lastCardPos.position, scale);
            lastIndex = cardNum;
        }
        else if (cardNum >= 3)
        {
            newPos = findNextPos(lastIndex, cardNum, lastCardPos.position.x, 0.2f);

            lastCardPos.position = new Vector3(newPos, transform.position.y, transform.position.z);
            firstCardPos.position = new Vector3(-newPos, transform.position.y, transform.position.z);
            var step = (lastCardPos.position.x-firstCardPos.position.x)/(cardNum-1);
            GameObject card;
            for (int i = 0; i < cards.Count; i++)
            {
                if (i == 0)
                {
                    card = cards[0].gameObject;
                    card.GetComponent<CardAnimator>().MoveAndScaleObject(firstCardPos.position, scale);
                    continue;
                }
                else if(i+1 == cards.Count)
                {
                    card = cards[i].gameObject;
                    card.GetComponent<CardAnimator>().MoveAndScaleObject(lastCardPos.position, scale);
                    continue;
                }

                var x = firstCardPos.position.x+ step*i;
                var pos = new Vector3(x,transform.position.y,transform.position.z);
                card = cards[i].gameObject;
                card.GetComponent<CardAnimator>().MoveAndScaleObject(pos, scale);

            }
            lastIndex = cardNum;
        }
    }

    // Function to start movement and scaling coroutines

    public float findNextPos(int lastIndex, int cardNum, float currentPos, float goalStep)
    {
        if (cardNum > lastIndex)
        {
            return currentPos + goalStep;
        }
        else if (cardNum < lastIndex)
        {
            return currentPos - goalStep;
        }
        else
        {
            return 0;
        }
    }
}