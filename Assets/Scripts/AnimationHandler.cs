using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    List<AnimationClip> animations;
    AnimatorOverrideController controller;
    public Animator animator;
    public AnimationClipOverrides clipOverrides;
    private GameBrain gameBrain;
    // Start is called before the first frame update
    void Start()
    {
        animations = new List<AnimationClip>();
        controller = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = controller;
        clipOverrides = new AnimationClipOverrides(controller.overridesCount);
        controller.GetOverrides(clipOverrides);

        GameObject ob = GameObject.FindGameObjectWithTag("GameBrain");
        if (ob != null)
        {
            gameBrain = ob.GetComponent<GameBrain>();
            Debug.Log("GameBrain found");
        }
    }

    

    public void addAnimation( List<AnimationClip> animationClips)
    {
        this.animations = animationClips;
        SetDanceAnimations();
    }

    void SetDanceAnimations()
    {
        Debug.Log("I am inside the fun");
        clipOverrides["Dance 1"] = animations[0];
        clipOverrides["Dance 2"] = animations[1];
        clipOverrides["Dance 3"] = animations[2];
        controller.ApplyOverrides(clipOverrides);
        Debug.Log("I am at the end of fun");
        playAnim();
    }

    void playAnim()
    {
        animator.SetTrigger("isDancing");
    }

    public void playInstantAnim(AnimationClip clip)
    {
        clipOverrides["Instant"] = clip;
        animator.SetTrigger("Instant");
    }

    public void endTurn()
    {
        gameBrain.setBattleState();
    }

    
}

public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
{
    public AnimationClipOverrides(int capacity) : base(capacity) { }

    public AnimationClip this[string name]
    {
        get { return this.Find(x => x.Key.name.Equals(name)).Value; }
        set
        {
            int index = this.FindIndex(x => x.Key.name.Equals(name));
            if (index != -1)
                this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
        }
    }
}
