using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//통과 조건을 달성해야 지나갈 수 있음
public class PassConditionsAchievement : MonoBehaviour
{
    private BoxCollider2D boxCollider = null;
    private bool isCanPass = false;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //통과 조건을 달성했을때 이 함수 실행
    private void ConditionsAchievement()
    {
        if (!isCanPass)
        {
            isCanPass = true;
            boxCollider.enabled = false;
        }
    }
}
