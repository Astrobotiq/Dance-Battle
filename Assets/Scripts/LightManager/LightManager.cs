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
    private void Awake()
    {
        rotateCount = 0;
        startRot = 50;
        backLightIdle();
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

    public void backLightIdle()
    {
        startRot += startRot + angle2;
        angle2 = -angle2;
        for (int i = 0;i<lightsBack.Count;i++)
        {
            var rotation = lightsBack[i].transform.rotation;
            if (i == lightsBack.Count - 1)
            {
                lightsBack[i].transform.DORotate(new Vector3(startRot, rotation.y, rotation.z),1f).OnComplete(backLightIdle);
            }
            lightsBack[i].transform.DORotate(new Vector3(startRot, rotation.y, rotation.z), 1f);
        }
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
