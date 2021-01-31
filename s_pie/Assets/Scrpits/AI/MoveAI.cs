using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    #region 목적지 이동 위한 변수

    [Header("AI가 목표로 가는 목적지들.")]
    [SerializeField] private GameObject[] destination    = null;
    [Header("이동 속도")]
    [SerializeField] private float        moveDelay      = 0.1f;

    private        NoticeAI noticeAI = null;
    private        int  des          = 0;                          // 배열 순환용
    private        bool isToGo       = true;                       // 배열 순환용
    private        bool isToGoBack   = false;                      // 배열 순환용
    private        bool isXSame      = false;                      // 이동용
    private        bool isYSame      = false;                      // 이동용
    private static bool isXBigger    = false;                      // 이동용
    private static bool isYBigger    = false;                      // 이동용
    public  static bool getIsXBigger { get { return isXBigger; } } // 외부 사용용
    public  static bool getIsYBigger { get { return isYBigger; } } // 외부 사용용

    // isToGo 와 isToGoBack 의 초기값
    /*
    if(isToGo == true)
        배열 앞에서 뒤로 출발
    else if(isToGoBack == true)
        배열 뒤에서 앞으로 출발
    */

    #endregion
    #region 에니메이션용 변수
    private SpriteAI anim = null;
    #endregion

    void Awake()
    {
        anim = FindObjectOfType<SpriteAI>();
        noticeAI = FindObjectOfType<NoticeAI>();

        // 뭐 빠트리고 실행시키면 귀찮으니
        if (!CheckDestinationStatus())
        { 
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

    //코드 추가한것
    #region AI가 턴으로 움직이도록 만든 코드
    public void AIMove()
    {
        if (!NoticeAI.getIsFound)
        {
            if(destination.Length > 1)
            {
                Partrol();
            }
        }
    }
    #endregion

    void Partrol()
    {
        PositionCalculate();
        CheckifArrived();
        if(!noticeAI.CheckFirst())
        {
            ToNextDestination();
        }
    }

    void ToNextDestination()
    {
        #region 직선 이동

        switch (isXSame)
        {
            case true: // 어차피 Y 는 실행이 되야 함
                switch (isYBigger)
                {
                    case true:
                        anim.AIDown(); // 점점 꼬여가는 코드
                        transform.DOMoveY(transform.position.y + 1, moveDelay);
                        break;
                    case false:
                        anim.AIUp();   // 이것이 밤 코딩
                        transform.DOMoveY(transform.position.y - 1, moveDelay);
                        break;
                }
                return; // 이거 안해주면 에러가 나는 신기한 C#
        }

        switch (isYSame)
        {
            case true: // 어차피 X 는 실행이 되야 함
                switch (isXBigger)
                {
                    case true:
                        transform.DOMoveX(transform.position.x + 1, moveDelay);
                        break;
                    case false:
                        transform.DOMoveX(transform.position.x - 1, moveDelay);
                        break;
                }
                return; // 이거 안해주면 에러가 나는 신기한 C#
        }

        #endregion
        #region 대각선 이동
        if (isYBigger && isXBigger)
        {
            //Debug.Log("1");
            transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y + 1), moveDelay);
        }
        else if (isYBigger && !isXBigger)
        {
            //Debug.Log("2");
            transform.DOMove(new Vector3(transform.position.x - 1, transform.position.y + 1), moveDelay);
        }
        else if (!isYBigger && isXBigger)
        {
            //Debug.Log("3");
            transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y - 1), moveDelay);
        }
        else
        {
            //Debug.Log("4");
            transform.DOMove(new Vector3(transform.position.x - 1, transform.position.y - 1), moveDelay);
        }
        #endregion
    }

    
    void CheckifArrived()
    {
        if (isXSame && isYSame)
        {
            #region 배열 끝 또는 시작 도착 여부
            /******************************************
             * 매우 중요함!
             * 더하거나 빼는 값을 바꾸면 절대로 안 돼요...
             * -우엽
            *******************************************/
            if (destination.Length == des + 2) 
            {
                isToGoBack = true;
                isToGo = false;
                // 되돌아가는 과정
            }
            else if (des == -1)
            {
                isToGo = true;
                isToGoBack = false;
                // 가는 과정
            }
            #endregion
            #region 배열 끝 또는 시작으로 이동
            if (isToGo)
            {
                ++des;
            }
            else if (isToGoBack)
            {
                --des;
            }
            #endregion
            isXSame = false;
            isYSame = false;
            PositionCalculate(); // 이거 없어도 문제는 없는데 AI 가 도착 후 한번 재미있게 움직임
        }
    }


    void PositionCalculate()
    {
        #region 만약 목적지 x좌표가 같거나 y좌표가 같다는 판단용
        if (!isXSame)
        {
            if (transform.position.x == destination[des + 1].transform.position.x)
            {
                //Debug.Log("XSame");
                isXSame = true;
            }
        }
        if (!isYSame)
        {
            if (transform.position.y == destination[des + 1].transform.position.y)
            {
                //Debug.Log("YSame");
                isYSame = true;
            }
        }
        #endregion // 이게 의미가 있는지는 모르겠는데 일단 해봤음
        #region 목적지 좌표가 현 좌표보다 큰지 작은지 판단용
        if (!isXSame)
        {
            if (transform.position.x < destination[des + 1].transform.position.x)
            {
                isXBigger = true;
            }
            else
            {
                isXBigger = false;
            }
        }
        if (!isYSame)
        {
            if (transform.position.y < destination[des + 1].transform.position.y)
            {
                isYBigger = true;
            }
            else
            {
                isYBigger = false;
            }
        }
        #endregion
    }

    /// <summary>
    /// 목적지 검사.
    /// </summary>
    /// <returns>문제 없을 시 true</returns>
    bool CheckDestinationStatus()
    {
        #region 에디터에서만 실행되는 구역
#if UNITY_EDITOR
        // 순찰 지점이 2개 미만이면 순찰을 못 돔
        if (destination.Length < 2)
        {
            UnityEditor.EditorUtility.DisplayDialog("AI 목적지 수 오류", "AI 의 순찰 지점이 너무 적습니다.", "확인");
            return false;
        }
        
        // 배열 중 비어있는 요소가 있다면 순찰을 못 돔
        for (int findNull = 0; findNull != destination.Length; ++findNull)
        {
            if (destination[findNull] == null)
            {
                UnityEditor.EditorUtility.DisplayDialog("AI 목적지 오류", "AI 의 순착 지점이 비어있습니다.", "확인");
                return false;
            }
        }

        // 에니메이션 스크립트 추가 안 되어있을때
        if(anim == null)
        {
            UnityEditor.EditorUtility.DisplayDialog("AI 에니메이션 오류", "SpriteAI 스크립트가 AI에 추가되어있는지 확인하세요.", "확인");
            return false;
        }
#endif
        #endregion

        #region AI 좌표와 첫 순찰 좌표가 다를 시 옮겨 줌
        if (destination[0].transform.position != transform.position)
        {
            transform.position = new Vector3(destination[0].transform.position.x, destination[0].transform.position.y, transform.position.z);
        }
        #endregion // 이게 꼭 필요한건가 궁금하기는 한데
        return true;
    }
}
