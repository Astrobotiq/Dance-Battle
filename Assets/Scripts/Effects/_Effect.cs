using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class _Effect : ScriptableObject
{
    public string description;
    public int delay;

    public enum priority
    {
        Low,Medium,High,PreTurn
    }
    //if priority low it will be played later

    public priority priorityValue;
    
    public abstract void PlayEffect();

    public int getDelay()
    {
        return delay;
    }
    
}
/*
 * multiply eden kartlar,
 * toplanacak kartlar seklinde
 * ayirirsak daha iyi olacak gibime geldi ondan string type ekledim
 * (enum da kullanilabilir belki ama simdilik boyle biraktim)
 */

/*
 * unutmadan kafamda nasil bir effect class kullanimi oldugunu yaziyorum
 * basit effectler icin direkt bu _Effect clasinin crowdPoint ve crowdMultiplayer degerlerini degistirerek kullanabiliriz
 * (kastettigim kartlar klasik 3 damage ver; 3 block yap gibi kartlar)
 * onun disinda Play turn yaptigimizda oynadigimiz kartlarin CardInfo classlarini icinde duracak ya bizim Effect classimiz
 * GameBrain ya da Score hangi class bakacaksa artik effectlerin ozellliklerini
 * o class, Effect class icindeki type bakarak
 * score'a henuz eklenememis geciciScore diyebilecegimiz parametreye eklenecek mi yoksa carpilacak mi sorusuna cevap verebilir
 */