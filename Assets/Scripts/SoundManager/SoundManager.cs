using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public delegate void ChangeColor();
    public event ChangeColor onColorChange;
    public MusicColor musicColor;
    [SerializeField] List<AudioClip> redClips;
    [SerializeField] List<AudioClip> blueClips;
    [SerializeField] List<AudioClip> greenClips;
    public Dictionary<MusicColor, List<AudioClip>> musics;

    [SerializeField] private AudioSource source;
    private void Awake()
    {
        musics.Add(MusicColor.RED, redClips);
        musics.Add(MusicColor.BLUE, blueClips);
        musics.Add(MusicColor.GREEN, greenClips);
        if(musicColor == null)
        {
            musicColor = MusicColor.RED;
        }

    }

    public void changeColor(int index)
    {
        if(index == 1)
        {
            musicColor = MusicColor.RED;
        }
        else if(index == 2)
        {
            musicColor = MusicColor.BLUE;
        }else if (index == 3)
        {
            musicColor=MusicColor.GREEN;
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

public enum MusicColor
{
    RED,GREEN,BLUE
}
