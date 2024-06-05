using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    List<AnimationClip> animations;
    AnimatorOverrideController controller;
    public Animator animator;
    public AnimationClipOverrides clipOverrides;
    private GameObject gameBrain;
    public GameObject parent;
    float animationTotalLength;
    Vector3 startPos;
    Quaternion rot;
    public LightManager lightManager;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rot = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        animations = new List<AnimationClip>();
        controller = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = controller;
        clipOverrides = new AnimationClipOverrides(controller.overridesCount);
        controller.GetOverrides(clipOverrides);

       gameBrain = GameObject.FindGameObjectWithTag("GameBrain");
        
    }

    private void OnEnable()
    {
        CrowdTurnState.onCrowdEnter += resetStarter;
    }

    IEnumerator resetPosition()
    {
        yield return new WaitForSeconds(5);
        transform.position = startPos;
        transform.rotation = rot;
    }

    public void resetStarter()
    {
        StartCoroutine(resetPosition());
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
        calculateTime();
    }

    void calculateTime()
    {
        List<float> times = new List<float>();
        foreach (AnimationClip clip in animations)
        {
            animationTotalLength += clip.length;
            times.Add(clip.length);
        }
        playAnim(times);
    }

    void playAnim(List<float> list)
    {
        animator.SetTrigger("isDancing");
        lightManager.lookAtCards(list);
        StartCoroutine(AnimationTimer());
    }

    public void playInstantAnim(AnimationClip clip)
    {
        clipOverrides["Instant"] = clip;
        animator.SetTrigger("Instant");
    }

    public void endTurn()
    {
        BattleState state;
        if(parent.gameObject.tag == "Enemy")
        {
            state = gameBrain.GetComponent<EnemyTurnState>();
            state.ExitState();
        }
        else if (parent.gameObject.tag == "Player")
        {
            state = gameBrain.GetComponent<PlayerTurnState>();
            state.ExitState();
        }
        
    }

    private IEnumerator AnimationTimer()
    {
        yield return new WaitForSeconds(animationTotalLength+2);
        animationTotalLength = 0;
        endTurn();
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
