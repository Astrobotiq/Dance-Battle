using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLightHandler : MonoBehaviour
{
    public Transform crowd;
    public List<GameObject> lights;
    public Vector3 offset;
    public List<Color> colors;
    bool willChange;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        willChange = false;
        index = 2;
        changeColor(index);
        decider();
    }

    // Update is called once per frame
   

    public void changeColor(int index)
    {
        Debug.Log("Lambalarýn renkleri degiþecek");
        foreach (var lightGO in lights)
        {
            Light light = lightGO.GetComponentInChildren<Light>();
            light.color = colors[index];
        }
    }

    public void changeInfo(int index)
    {
        willChange = true;
        this.index = index;
    }

    public void decider()
    {
        if (willChange)
        {
            changeColor(index);
        }
        look();
    }

    public void look()
    {
        offset = -offset;
        Vector3 lookPos = new Vector3(crowd.position.x + offset.x, crowd.position.y + offset.y, crowd.position.z + offset.z);
        lights[0].transform.DOLookAt(lookPos, 2);
        lights[1].transform.DOLookAt(lookPos, 2).OnComplete(decider);
    }


    private void OnEnable()
    {
        UIManager.onColorChangerDeactivate += changeInfo;
    }

    private void OnDisable()
    {
        UIManager.onColorChangerDeactivate -= changeInfo;
    }
}
