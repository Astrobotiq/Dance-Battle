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
    [SerializeField]
    CardFactory cardFactory;
    private int lastIndex;
    [SerializeField]
    private List<Card> cards;
    private int maxCard;
    public ShuffleHolder shuffleHolder;

    

    public int getMaxCard()
    {
        return maxCard;
    }

    public void setMaxCard(int add)
    {
        maxCard += add;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        cards = new List<Card>();
        lastIndex = 0;
        maxCard = 6;
        scale = new Vector3(0.05f, 1, 0.075f);
    }

    private void OnEnable()
    {
        SpecialTurn.onEnterSpecial += drawCard;
        WinState.onEnter += onWin;
    }

    private void OnDisable()
    {
        SpecialTurn.onEnterSpecial -= drawCard;
        WinState.onEnter += onWin;

    }

    public void Add(Card card)
    {
        cards.Add(card);
        calculatePos();
    }

    public void drawCard()
    {
        Debug.Log("special turn kart çekmek için event yolladý");
        StartCoroutine(drawTimer());
    }

    public Card Remove(Card card)
    {
        if (cards.Contains(card))
        {
            cards.Remove(card);
        }
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

    IEnumerator drawTimer()
    {
        yield return new WaitForSeconds(1);
        while (cards.Count < maxCard)
        {
            Debug.Log("Kart çekiliyor");
            cardFactory.getCard();
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void onWin()
    {
        foreach(Card card in cards)
        {
            shuffleHolder.Add(card.GetCardInfo());
            Destroy(card.gameObject);
        }
        cards.Clear();
        cards = new List<Card>();
        Debug.Log("Cardlar silindi");
    }
}
