using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 pos;
    Quaternion rot;
    public Transform playerPos; 
    private void Start()
    {
        pos = transform.position;
        rot = transform.rotation;
    }
    private void OnEnable()
    {
        CrowdTurnState.onCrowdEnter += coroutineStarter;
        UIManager.onWin += goToPlayer;
        
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
        transform.DORotate(rot.eulerAngles, 5);
    }

    public void goToPlayer()
    {
        transform.DOMoveZ(-5,2).SetEase(Ease.InOutSine);
        transform.DOLookAt(playerPos.position, 5f);
    }
}
