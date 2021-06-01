using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCheck : MonoBehaviour
{
    [SerializeField] private GameObject objectCheck = null; //오브젝트 확인 캔버스 게임 오브젝트
    [Header("여기에 상호작용 오브젝트를 모두 넣으면 됨")]
    [SerializeField] private SpriteRenderer[] interactionObjects; //상호작용 오브젝트

    public void ObjectCheckPointerDown() //버튼을 누르고 있을때
    {
        objectCheck.SetActive(true);
        
        for(int i = 0; i < interactionObjects.Length; i++) //상호작용 오브젝트를 오브젝트 확인 캔버스 앞으로 보냄
        {
            interactionObjects[i].sortingOrder = 1;
        }
    }

    public void ObjectCheckPointerUp() //버튼에서 손을 놓았을때
    {
        objectCheck.SetActive(false);

        for (int i = 0; i < interactionObjects.Length; i++) //상호작용 오브젝트를 오브젝트 확인 캔버스 뒤로 보냄
        {
            interactionObjects[i].sortingOrder = 0;
        }
    }
}
