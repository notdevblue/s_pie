using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAction : MonoBehaviour
{
    static private DetectAction inst; // static 핰수 접근 용도

    private Dictionary<DetectType, Action> detectedActionDict; // 무언가를 발견했을때 실행할 detectedActionDict

    private void Awake()
    {
        inst = this;
    }

    /// <summary>
    /// detectedActionList 에 OnDetected() 함수가 호출된 경우 key 에 따라 호출될 action 을 추가합니다. 
    /// </summary>
    /// <param name="key">DetectType enum</param>
    /// <param name="action">Called when detected</param>
    static public void AddDetectedAction(DetectType key, Action action)
    {
        if(!inst.detectedActionDict.ContainsKey(key))
        {
            inst.detectedActionDict.Add(key, action);
        }
        else
        {
            inst.detectedActionDict[key] += action;
        }
    }

    /// <summary>
    /// 주어진 key 에 따라 미리 추가된 Action 을 호출합니다.
    /// </summary>
    /// <param name="key">탐지된 오브젝트의 Key</param>
    static public void OnDetected(DetectType key)
    {
        if(!inst.detectedActionDict.ContainsKey(key))
        {
            Debug.LogError($"DetectedAction: 주어진 키: {key} 를 찾을 수 없습니다.\r\nObjectName: {inst.gameObject.name}");
            return;
        }

        inst.detectedActionDict[key](); // <= 절때 null 이 나올 수 없어서 그냥 호출함
    }
}
