using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePlatform : MonoBehaviour
{
    public bool IsOn;
    public float TimeBeforeFade;
    public float TimeToComeBack;
    private MeshRenderer _linkedObjectMesh;
    private Collider _linkedObjectCollider;

    private void Awake()
    {
        _linkedObjectMesh = transform.parent.GetComponent<MeshRenderer>();
        _linkedObjectCollider = transform.parent.GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        StopAllCoroutines();
        StartCoroutine(FadeCoroutine());
    }
    /* private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
        StartCoroutine(ComeBackCoroutine());
    } */
    private IEnumerator FadeCoroutine()
    {
        yield return new WaitForSeconds(TimeBeforeFade);
        Toggle(false);
    }
    private IEnumerator ComeBackCoroutine()
    {
        yield return new WaitForSeconds(TimeToComeBack);
        Toggle(true);
    }
    public void Toggle(bool b)
    {
        IsOn = b;
        if (_linkedObjectCollider)
        {
            _linkedObjectCollider.enabled = b;
        }
        if (_linkedObjectMesh)
        {
            _linkedObjectMesh.enabled = b;
        }
        if (!b)
        {
            StopAllCoroutines();
            StartCoroutine(ComeBackCoroutine());
        }
    }
}
