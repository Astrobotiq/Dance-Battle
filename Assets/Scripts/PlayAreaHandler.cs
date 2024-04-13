using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAreaHandler : MonoBehaviour
{
    List<AnimationClip> animations;
    // Start is called before the first frame update
    void Start()
    {
        animations = new List<AnimationClip>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addAnim(AnimationClip clip,int index)
    {
        animations.Insert(index,clip);
    }

    public void removeAnim(int index)
    {
        animations.RemoveAt(index);
    }
}
