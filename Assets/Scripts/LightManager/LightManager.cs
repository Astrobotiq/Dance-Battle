using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{

    public List<GameObject> lights;
    public int angle;
    public GameObject player;
    public GameObject enemy;
    public GameObject ceiling;
    private void Awake()
    {
        rotateGO();
    }

    public void rotateGO()
    {

        ceiling.transform.DORotate(new Vector3(0, 180, 0), 5f).OnComplete(rotateLight);
    }

    public void rotateLight()
    {
        angle = -angle;
        lights[0].transform.DORotate(new Vector3(90 + angle, 0, 0), 0.5f).SetEase(Ease.Linear);
        changeColor(lights[0]);
        lights[1].transform.DORotate(new Vector3(90 + angle, 0, 0), 0.5f).SetEase(Ease.Linear);
        changeColor(lights[1]);
        lights[2].transform.DORotate(new Vector3(90 + angle, 0, 0), 0.5f).SetEase(Ease.Linear).OnComplete(lookAtPlayer);
        changeColor(lights[2]);

    }

    public void changeColor(GameObject light)
    {
        light.GetComponent<Light>().DOColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 0.5f);
    }

    public void lookAtPlayer()
    {
        lights[2].transform.DOLookAt(player.transform.position, 2f).OnComplete(lookAtEnemy);
    }

    public void lookAtEnemy()
    {
        lights[1].transform.DOLookAt(enemy.transform.position, 2f).OnComplete(rotateLight);
    }

}
