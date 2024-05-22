using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 pos;
    private void Start()
    {
        pos = transform.position;
    }
    private void OnEnable()
    {
        CrowdTurnState.onCrowdEnter += coroutineStarter;
        
    }

    private void OnDisable()
    {
        CrowdTurnState.onCrowdEnter -= coroutineStarter;
    }

    public void coroutineStarter()
    {
        StartCoroutine(cameraTimer());
    }

    IEnumerator cameraTimer()
    {
        goToCrowd();
        yield return new WaitForSeconds(6f);
        reset();
    }


    public void goToCrowd()
    {
        transform.DOMoveZ(-2, 3).SetEase(Ease.InOutSine);
    }

    public void reset()
    {
        transform.DOMove(pos,3).SetEase(Ease.InCubic);
    }
}
