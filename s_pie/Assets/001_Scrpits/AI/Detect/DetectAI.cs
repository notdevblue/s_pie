using System;
using System.Collections.Generic;
using UnityEngine;

public class DetectAI : MonoBehaviour
{
    // 컬라이더 안에 들어오게 되면 오브젝트에게 Detectable 을 GetComponent 시도한 경우, dictionary[type] 에 따라 올바른 발행을 함
    // (구독 발행 패턴)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Detectable detect = collision.gameObject.GetComponent<Detectable>();
        if (detect != null)
        {
            DetectAction.OnDetected(detect.type);
        }
    }
}