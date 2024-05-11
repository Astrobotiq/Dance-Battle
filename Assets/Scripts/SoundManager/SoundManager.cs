using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public delegate void ChangeColor();
    public event ChangeColor onColorChange;
    public MusicColor musicColor;
    public Dictionary<MusicColor, List<AudioClip>> musics;

    [SerializeField] private AudioSource source;
    private void Awake()
    {
        if(musicColor == null)
        {
            musicColor = MusicColor.RED;
        }
    }

    public void changeColor(MusicColor color)
    {
        musicColor = color;
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
