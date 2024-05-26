using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public delegate void ChangeColor();
    public event ChangeColor onColorChange;
    public CardColor musicColor;
    [SerializeField] List<AudioClip> redClips;
    [SerializeField] List<AudioClip> purpleClips;
    [SerializeField] List<AudioClip> pinkClips;
    public Dictionary<CardColor, List<AudioClip>> musics;

    [SerializeField] private AudioSource source;
    private void Awake()
    {
        musics.Add(CardColor.RED, redClips);
        musics.Add(CardColor.PURPLE, purpleClips);
        musics.Add(CardColor.PINK, pinkClips);
        if(musicColor == null)
        {
            musicColor = CardColor.RED;
        }

    }

    public void changeColor(int index)
    {
        if(index == 1)
        {
            musicColor = CardColor.RED;
        }
        else if(index == 2)
        {
            musicColor = CardColor.PURPLE;
        }else if (index == 3)
        {
            musicColor=CardColor.PINK;
        }
        changeMusic();
    }

    private void changeMusic()
    {
        if (musics.TryGetValue(musicColor, out List<AudioClip> audioClips))
        {
            int len = audioClips.Count;
            int index = Random.Range(0, len);
            source.clip = audioClips[index];
            onColorChange?.Invoke();
            source.Play();
        }
    }

}


