using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public delegate void UIEvents();
    //this will be using when color change card played
    public static event UIEvents onColorChangerActivate;
    public static event UIEvents onColorChangerDeactivate;
    public GameObject colorChange;
    

    public void activateColorChanger()
    {
        onColorChangerActivate?.Invoke(); // yakalayan scriptleri yaz. Mesela gameBrain oyunu durdursun. ses efekti oynansýn. 
        colorChange.SetActive(true);
    }

    public void deactivateColorChanger()
    {
        onColorChangerDeactivate?.Invoke();// yakalayan scriptleri yaz. Mesela gameBrain oyunu devam ettirsin. ses efekti oynansýn. 
        colorChange.SetActive(false);
    }
}
