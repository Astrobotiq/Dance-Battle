using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimator : MonoBehaviour
{
    Vector3 unHoverPosition;
    Vector3 unHoverScale;

    


    public void MoveAndScaleObject(Vector3 targetPosition, Vector3 targetScale)
    {
        StartCoroutine(disableCollider());
        StartCoroutine(MoveObjectCoroutine( targetPosition));
        StartCoroutine(ScaleObjectCoroutine(targetScale));
    }

    // Coroutine to move the object to the target position
    IEnumerator MoveObjectCoroutine(Vector3 targetPosition)
    {
        // Move the object to the target position over 1 second using Dotween
        transform.DOMove(targetPosition, 1f);

        // Wait for the movement to complete
        yield return new WaitForSeconds(1f);
    }

    // Coroutine to scale the object to the target scale
    IEnumerator ScaleObjectCoroutine(Vector3 targetScale)
    {
        // Scale the object to the target scale over 1 second using Dotween
        transform.DOScale(targetScale, 1f);

        // Wait for the scaling to complete
        yield return new WaitForSeconds(1f);
    }

    public void hover()
    {
        unHoverPosition = transform.position;
        unHoverScale = transform.localScale;
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
        Vector3 targetScale = new Vector3(transform.localScale.x*2, transform.localScale.y, transform.localScale.z*2);
        MoveAndScaleObject(targetPos,targetScale);
    }

    public void unHover()
    {
        MoveAndScaleObject(unHoverPosition,unHoverScale);
    }

    IEnumerator disableCollider()
    {
        GetComponent<MeshCollider>().enabled = false;
        yield return new  WaitForSeconds(1f);
        GetComponent<MeshCollider>().enabled = true;
    }

}
