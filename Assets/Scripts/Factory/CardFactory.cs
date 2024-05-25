using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    //This class will implemented as soon as possible.Probably on week 2
    //We will use it as instantiator of cards
    [SerializeField]
    private GameObject cardPrefab;
    [SerializeField]
    private ShuffleHolder shuffleHolder;
    [SerializeField]
    private HandHolder handHolder;
    public Transform BornPos;
    public List<Material> redMaterials;
    public List<Material> purpleMaterials;
    public List<Material> pinkMaterials;

    private void Awake()
    {
        if (cardPrefab == null)
        {
            Debug.Log("There are no Prefab");
        }
    }

    public void build(CardInfo card)
    {
        if (card != null && cardPrefab != null)
        {
            GameObject cardObject = Instantiate(cardPrefab, BornPos.position, Quaternion.identity);
            cardObject.transform.localEulerAngles = new Vector3(90,180,0);

            if (cardObject != null)
            {
                cardObject.GetComponent<Card>().setCardInfo(card);
            }
            cardObject.GetComponent<MeshRenderer>().material = getCardMaterial(card);
            handHolder.Add(cardObject.GetComponent<Card>());
        }
    }

    public void getCard()
    {
        CardInfo card = shuffleHolder.Draw();
        if (card != null)
        {
            Debug.Log("Card taken");
            build(card);
        }
    }

    public Material getCardMaterial(CardInfo cardInfo)
    {
        Material material = null;
        if (cardInfo.GetCardColor() == CardColor.RED)
        {
            material = redMaterials[0];
        }
        else if (cardInfo.GetCardColor() == CardColor.PURPLE)
        {
            material = purpleMaterials[0];
        }
        else
        {

            material = pinkMaterials[0];

        }
        return material;
    }
}
