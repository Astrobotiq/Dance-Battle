using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowd : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;
    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void getExited()
    {
        StartCoroutine(setSprites(1));
    }

    public void getBored()
    {
        StartCoroutine(setSprites(0));
    }
    
    IEnumerator setSprites(int i )
    {
        yield return new WaitForSeconds(3);
        spriteRenderer.sprite = sprites[i];
    }


    public void resetSprite()
    {
        //will be implement
    }

    private void OnEnable()
    {
        CrowdTurnState.onCrowdExit += getBored;
    }
}
