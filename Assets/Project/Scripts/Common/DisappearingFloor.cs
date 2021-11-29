using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingFloor : MonoBehaviour
{
    [SerializeField] GameObject disappearingFloor;
    [SerializeField] float disappearColliderTime = 3f;
    [SerializeField] float disappearRendererTime = 0.5f;
    [SerializeField] float reproductionTime = 3f;

    private Renderer floorRenderer;
    private BoxCollider floorBoxCollider;

    private bool isTouchFloor = false;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && !isTouchFloor)
        {
            StartCoroutine(DelayCoroutine());
        }
    }

    // コルーチン本体
    private IEnumerator DelayCoroutine()
    {
        floorRenderer = disappearingFloor.GetComponent<Renderer>();
        floorBoxCollider = disappearingFloor.GetComponent<BoxCollider>();

        isTouchFloor = true;
        yield return new WaitForSeconds(disappearColliderTime);
        floorBoxCollider.enabled = false;
        yield return new WaitForSeconds(disappearRendererTime);
        floorRenderer.enabled = false;

        yield return new WaitForSeconds(reproductionTime);
        floorRenderer.enabled = true;
        floorBoxCollider.enabled = true;
        isTouchFloor = false;
    }
}
