using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Effect", menuName = "Effects/Additional Card Effect")]
public class AdditionalCardEffect : _Effect
{
    public int additionAmount;

    public override void PlayEffect()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
