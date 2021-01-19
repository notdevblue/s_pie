using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 클래스 이름이 좀 애매하긴 한데,
/// 플레이어를 탐색하는 용도의 클래스 입니다.
/// </summary>
public class NoticeAI : MonoBehaviour
{
    #region 변수들
    private        int  notice            = 0;
    private static bool isFound           = false;
    private static bool isAINoticedPlayer = false;
    public  static bool getIsFound        { get { return isFound; } } // 으으흠.
    public  static bool getIsAINoticed    { get { return isFound; } } // 으흐음.

    [Header("플레이어를 인식할 거리")]
    [SerializeField] private float      detectRange = 1.0f;
    [SerializeField] private GameObject player      = null;
    #endregion


    void Awake()
    {
        #region 에디터용 코드
        if (player == null)
        {
            UnityEditor.EditorUtility.DisplayDialog("AI 오류", "AI 가 찾을 플레이어가 없습니다", "확인");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        #endregion
    }

    public void AILookUp()
    {
        LookForPlayer();
        NoticePlayer();
    }

    void LookForPlayer()
    {
        #region 한번 갈아 엎어야 했었음
        // 이유: 사람 실제 시아는 앞을 제일 잘 봄
        // 코드: 반원 안에 들어오면 다 발견함
        // 결론: 기능이 사실적이지 않음
        // 망상: 삼각함수 각?

        if (Vector3.Distance(transform.position, player.transform.position) > detectRange)
        {
            --notice;
            isFound = false;
        }
        else
        {
            // 뒤에 있으면 못 보는게 정상이었지만 맵이 체스판 모양이니.
            //if(player.transform.position.x > transform.position.x)
            //{
                ++notice;
                isFound = true;
            //}
        }
        #endregion
    }

    void NoticePlayer()
    {
        if(notice == 3)
        {
            isAINoticedPlayer = true;
            //Debug.Log("AI 가 플레이어를 발견함");
        }
    }

}
