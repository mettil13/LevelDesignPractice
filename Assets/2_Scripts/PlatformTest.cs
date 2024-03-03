using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlatformTest : MonoBehaviour
{
    private void Start()
    {
        transform.DOMove(transform.position + Vector3.up * 3, 1).SetLoops(-1, LoopType.Yoyo);
    }
}
