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
        spriteRenderer.sprite = sprites[1];
    }

    public void getBored()
    {
        spriteRenderer.sprite = sprites[0];
    }
}
