using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{

    public List<GameObject> lightsMiddle;
    public List<GameObject> lightsBack;
    public int angle;
    public int angle2;
    public GameObject player;
    public GameObject enemy;
    public GameObject ceiling;
    private int startRot;
    private int rotateCount;
    public List<Transform> cubes;
    private void Awake()
    {
        rotateCount = 0;
        startRot = 50;
    }

    public void rotateGO()
    {

        ceiling.transform.DORotate(new Vector3(0, 180, 0), 5f);
    }

    IEnumerator rotateLight()
    {
        angle = -angle;
        lightsMiddle[0].transform.DORotate(new Vector3(90 + angle, 0, 0), 0.5f).SetEase(Ease.Linear);
        changeColor(lightsMiddle[0]);
        lightsMiddle[1].transform.DORotate(new Vector3(90 + angle, 0, 0), 0.5f).SetEase(Ease.Linear);
        changeColor(lightsMiddle[1]);
        lightsMiddle[2].transform.DORotate(new Vector3(90 + angle, 0, 0), 0.5f).SetEase(Ease.Linear).OnComplete(restart);
        changeColor(lightsMiddle[2]);
        yield return null;
    }

    private void restart()
    {
        if (rotateCount<4)
        {
            lightsMiddle[0].transform.DORotate(new Vector3(90, 0, 0), 0.5f).SetEase(Ease.Linear);
            changeColor(lightsMiddle[0]);
            lightsMiddle[1].transform.DORotate(new Vector3(90, 0, 0), 0.5f).SetEase(Ease.Linear);
            changeColor(lightsMiddle[1]);
            lightsMiddle[2].transform.DORotate(new Vector3(90, 0, 0), 0.5f).SetEase(Ease.Linear).OnComplete(caller);
            changeColor(lightsMiddle[2]);
        }
        else if (rotateCount>=4)
        {
            rotateCount = 0;
        }
        
    }

    public void lookAtCards(List<float> list)
    {
        lightsMiddle[1].transform.DOLookAt(cubes[0].position, list[0]).SetEase(Ease.Linear).OnComplete( () =>
            lightsMiddle[1].transform.DOLookAt(cubes[1].position, list[1]).SetEase(Ease.Linear).OnComplete(() =>
                lightsMiddle[2].transform.DOLookAt(cubes[2].position, list[2]).SetEase(Ease.Linear)
            )
        );
    }

    private void caller()
    {
        rotateCount++;
        StartCoroutine(rotateLight());
    }

    public void changeColor(GameObject light)
    {
        light.GetComponent<Light>().DOColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 0.5f);
    }

    public void lookAtPlayer()
    {
        lightsMiddle[2].transform.DOLookAt(player.transform.position, 2f);
    }

    public void lookAtEnemy()
    {
        lightsMiddle[1].transform.DOLookAt(enemy.transform.position, 2f);
    }

    public void frontIdle()
    {
        StopCoroutine(rotateLight());
        lightsMiddle[0].transform.DORotate(new Vector3(90, 0, 0), 0.5f).SetEase(Ease.Linear);
        changeColor(lightsMiddle[0]);
        lightsMiddle[1].transform.DORotate(new Vector3(90, 0, 0), 0.5f).SetEase(Ease.Linear);
        changeColor(lightsMiddle[1]);
        lightsMiddle[2].transform.DORotate(new Vector3(90, 0, 0), 0.5f).SetEase(Ease.Linear);
        changeColor(lightsMiddle[2]);
    }


    private void OnEnable()
    {
        SpecialTurn.onEnterSpecial += rotateGO;
        PlayerTurnState.onPlayerTurnStart += lookAtPlayer;
        PlayerTurnState.onPlayerTurnEnd += frontIdle;
        EnemyTurnState.onEnemyTurnStart += lookAtEnemy;
        EnemyTurnState.onEnemyTurnEnd += frontIdle;
        CrowdTurnState.onCrowdEnter += restart;
        CrowdTurnState.onCrowdExit += frontIdle;
    }

}
