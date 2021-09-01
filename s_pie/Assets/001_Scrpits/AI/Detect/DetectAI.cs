using System;
using System.Collections.Generic;
using UnityEngine;

public class DetectAI : MonoBehaviour
{
    Action onDetectPlayer;

    private void Awake() {
        onDetectPlayer = () =>
        {
            Debug.Log("Player Detected:");
        };
    }

    // TODO : 풀메니저에 담아둘 것
    private void OnEnable()
    {
        DetectAction.AddDetectedAction(DetectType.Player, onDetectPlayer);
    }


    // 컬라이더 안에 들어오게 되면 오브젝트에게 Detectable 을 GetComponent 시도한 경우, dictionary[type] 에 따라 올바른 발행을 함
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetectAction.OnDetected(DetectType.Player);
        // Detectable detect = collision.gameObject.GetComponent<Detectable>();
        // if (detect != null)
        // {
        //     DetectAction.OnDetected(detect.type);
        // }
    }
}