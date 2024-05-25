using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/ChangeColorEfect")]
public class ChangeColor : _Effect
{
    public override void PlayEffect()
    {
        GameObject go = GameObject.FindWithTag("Canvas Manager");
        UIManager manager = go.GetComponent<UIManager>();
        manager.activateColorChanger();
    }
}
