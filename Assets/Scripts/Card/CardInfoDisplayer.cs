using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardInfoDisplayer : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro name;

    [SerializeField]
    private TextMeshPro type;

    public void display(string name, string type)
    {
        this.name.text = name;
        this.type.text = type;

    }

}
