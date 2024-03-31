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

    private int lastIndex;

    List<Card> cards;

    DG.Tweening.Sequence sequence;
    

    // Start is called before the first frame update
    void Start()
    {
        cards = new List<Card>();
        lastIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        sequence = DOTween.Sequence();
        int cardNum = cards.Capacity;
        float newPos;
        if (cardNum == 1)
        {
            lastCardPos.position = transform.position;
            firstCardPos.position = transform.position;
            sequence.Append(cards[0].gameObject.transform.DOMove(lastCardPos.position,1f));
            lastIndex = cardNum;
        }
        else if(cardNum == 2)
        {
            if (lastIndex < cardNum)
            {
                newPos = transform.position.x + 0.2f;
            }
            else { newPos = transform.position.x - 0.2f; }
            lastCardPos.position = new Vector3(newPos, transform.position.y,transform.position.z);
            firstCardPos.position = new Vector3(-newPos, transform.position.y, transform.position.z);
            sequence.Append(cards[0].gameObject.transform.DOMove(firstCardPos.position, 1f));
            sequence.Append(cards[1].gameObject.transform.DOMove(lastCardPos.position, 1f));
        }
        else if (cardNum >= 3)
        {
            if (lastIndex < cardNum)
            {
                newPos = transform.position.x + 0.15f;
            }
            else { newPos = transform.position.x - 0.15f; }
            lastCardPos.position = new Vector3(newPos, transform.position.y, transform.position.z);
            firstCardPos.position = new Vector3(-newPos, transform.position.y, transform.position.z);
            var step = Vector3.Distance(lastCardPos.position,firstCardPos.position)/cards.Count-2;
            for (int i = 0; i < cards.Count; i++)
            {
                if (i == 0)
                {
                    sequence.Append(cards[0].gameObject.transform.DOMove(firstCardPos.position, 1f));
                    continue;
                }
                else if(i+1 == cards.Count)
                {
                    sequence.Append(cards[i].gameObject.transform.DOMove(lastCardPos.position, 1f));
                    continue;
                }

                var pos = new Vector3(transform.position.x+step,transform.position.y,transform.position.z);
                sequence.Append(cards[i].gameObject.transform.DOMove(pos, 1f));
            }
        }
    }
}
