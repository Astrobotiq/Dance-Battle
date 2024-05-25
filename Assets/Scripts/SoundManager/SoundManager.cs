using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public delegate void ChangeColor();
    public event ChangeColor onColorChange;
<<<<<<< Updated upstream
    public CardColor musicColor;
    [SerializeField] List<AudioClip> redClips;
    [SerializeField] List<AudioClip> purpleClips;
    [SerializeField] List<AudioClip> pinkClips;
    public Dictionary<CardColor, List<AudioClip>> musics;
=======
    public MusicColor musicColor;
    [SerializeField] private AudioClip defaultMusic;
    [SerializeField] List<AudioClip> redClips;
    [SerializeField] List<AudioClip> blueClips;
    [SerializeField] List<AudioClip> greenClips;
    public Dictionary<MusicColor, List<AudioClip>> musics;
    public float duration;
>>>>>>> Stashed changes

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

    public void crowdSoundEffectCall(AudioClip audioClip)
    {
        StartCoroutine(changeSoundForCrowd(audioClip,duration));
    }

    IEnumerator changeSoundForCrowd(AudioClip audioClip, float duration)
    {
        AudioClip previousSound = source.clip;
        source.clip = audioClip;
        yield return new WaitForSeconds(duration);
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        source.clip = defaultMusic;
        source.Play();
    }

}


