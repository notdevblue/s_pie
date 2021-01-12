using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 대충 하는 일 설명
/*
A 지점에서 B 지점까지 간다.
GameObject 의 첫 원소부터 끝 원소까지 이동 후 다시 첫 원소까지 이동

destination[0] = (1, 1);
destination[1] = (2, 1);
destination[2] = (3, 2);
인 경우
1,1 에서 출발하고 2,1 을 경유해서 3,2 로 가서 다시 2,1 을 경우해서 1,1 로 돌아옴
*/

/// <summary>
/// 이동하는 AI 의 움직임.
/// 지점 A 부터 어딘가를 경유하거나 바로 B 까지 움직이는 용도의 클래스
/// </summary>
public class MoveAI : MonoBehaviour
{
    // 이걸 Vector2 보다는 게임오브젝트로 하는게 더 편할거 같음
    //[SerializeField] Vector2[] destination;
    [Header("AI가 목표로 가는 목적지들.")]
    [SerializeField] GameObject[] destination;

    #region 목적지 이동 위한 변수
    private int des = 0;
    private bool isXSame = false;
    private bool isYSame = false;
    private bool isXBigger = false;
    private bool isYBigger = false;
    /// <summary>
    /// 최적화가 이런거로 되나?
    /// </summary>
    private bool calculated = false;
    #endregion


    void Start()
    {
        if(!CheckDestinationStatus())
            UnityEditor.EditorApplication.isPlaying = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Partrol();
        }
    }

    void Partrol()
    {
        if (destination[des] == destination[des + 1])
        {
            ++des;
            isXSame = false;
            isYSame = false;
            calculated = false;
        }

        switch(calculated)
        {
            case false:
                PositionCalculate();
                break;
        }
    }

    void PositionCalculate()
    {
        #region 만약 목적지 x좌표가 같거나 y좌표가 같다는 판단용
        if (!isXSame)
        {
            if (destination[des].transform.position.x == destination[des + 1].transform.position.x)
                isXSame = true;
        }
        if (!isYSame)
        {
            if (destination[des].transform.position.y == destination[des + 1].transform.position.y)
                isYSame = true;
        }
        #endregion // 이게 의미가 있는지는 모르겠는데 일단 해봤음
        #region 목적지 좌표가 현 좌표보다 큰지 작은지 판단용
        if (!isXSame)
        {
            if (destination[des].transform.position.x < destination[des + 1].transform.position.x)
                isXBigger = false;
        }
        if (!isYSame)
        {
            if (destination[des].transform.position.y < destination[des + 1].transform.position.y)
                isYBigger = false;
        }
        #endregion
        calculated = true;
    }


    /// <summary>
    /// 목적지 검사
    /// </summary>
    /// <returns>문제 없을 시 true</returns>
    bool CheckDestinationStatus()
    {
        if (destination.Length < 2)
        {
            UnityEditor.EditorUtility.DisplayDialog("AI 목적지 수 오류", "AI 의 순찰 지점이 너무 적습니다.", "확인");
            return false;
        }
        for (int findNull = 0; findNull != destination.Length; ++findNull)
        {
            if (destination[findNull] == null)
            {
                UnityEditor.EditorUtility.DisplayDialog("AI 목적지 오류", "AI 의 순착 지점이 비어있습니다.", "확인");
                return false;
            }
        }
        return true;
    }
}
