using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLightHandler : MonoBehaviour
{
    public Transform crowd;
    public List<GameObject> lights;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        look();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void look()
    {
        offset = -offset;
        Vector3 lookPos = new Vector3(crowd.position.x + offset.x, crowd.position.y + offset.y, crowd.position.z + offset.z);
        lights[0].transform.DOLookAt(lookPos, 2);
        lights[1].transform.DOLookAt(lookPos, 2).OnComplete(look);
    }
}
