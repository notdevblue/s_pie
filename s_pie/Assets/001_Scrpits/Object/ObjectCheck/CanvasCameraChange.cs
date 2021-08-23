using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCameraChange : MonoBehaviour
{
    [SerializeField] private Transform playerPosition; //플레이어 위치
    [SerializeField] private Canvas objectCheckCanvas; //오브젝트 확인 캔버스
    [SerializeField] private Camera camera1F; //1층 카메라
    [SerializeField] private Camera camera2F; //2층 카메라

    public void PlayerFloorCheck()
    {
        if(playerPosition.localPosition.y < 6f)
        {
            //1층
            if(objectCheckCanvas.worldCamera != camera1F)
            {
                objectCheckCanvas.worldCamera = camera1F;
            }
        }
        else
        {
            //2층
            if (objectCheckCanvas.worldCamera != camera2F)
            {
                objectCheckCanvas.worldCamera = camera2F;
            }
        }
    }
}
