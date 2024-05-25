using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardInfoDisplayer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI name;


    public void display(string name)
    {
        this.name.text = name;

    }

}
