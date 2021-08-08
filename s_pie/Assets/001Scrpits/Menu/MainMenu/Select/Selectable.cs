using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    [Header("카메라 이동 관련")]
    [Header("로딩화면 위치")]
    public Transform loadingTrm = null;

    [Header("카메라 이동 위치")]
    public Transform moveTo = null;

    [Header("이동 시간")]
    public float duration = 2.0f;

    [Header("조명 관련")]
    [Header("인덱스")]
    public int       index  = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LightSelectManager.isSelected) return;
        LightSelectManager.LightOn(index);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LightSelectManager.isSelected) return;
        LightSelectManager.LightOff(index);
    }

    public void OnSelected()
    {
        CameraMover.MoveCamera(moveTo.position, duration);
    }
}
