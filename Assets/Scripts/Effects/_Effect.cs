using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Effect : MonoBehaviour
{
    public string description;
    public float crowdPoint = 1f;
    public float crowdMultiplier = 1f;
    public string type;
    /*
     * multiply eden kartlar,
     * toplanacak kartlar seklinde
     * ayirirsak daha iyi olacak gibime geldi ondan string type ekledim
     * (enum da kullanilabilir belki ama simdilik boyle biraktim)
     */ 

    public float PlayEffect()
    {
        return crowdPoint * crowdMultiplier;
    }
    
    /*
     * unutmadan kafamda nasil bir effect class kullanimi oldugunu yaziyorum
     * basit effectler icin direkt bu _Effect clasinin crowdPoint ve crowdMultiplayer degerlerini degistirerek kullanabiliriz
     * (kastettigim kartlar klasik 3 damage ver; 3 block yap gibi kartlar)
     * onun disinda Play turn yaptigimizda oynadigimiz kartlarin CardInfo classlarini icinde duracak ya bizim Effect classimiz
     * GameBrain ya da Score hangi class bakacaksa artik effectlerin ozellliklerini
     * o class, Effect class icindeki type bakarak
     * score'a henuz eklenememis geciciScore diyebilecegimiz parametreye eklenecek mi yoksa carpilacak mi sorusuna cevap verebilir  
     */
}
