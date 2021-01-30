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
    private        float    maxX              = 0.0f;
    private        float    minX              = 0.0f;
    private        float    maxY              = 0.0f;
    private        float    minY              = 0.0f;
    private        int      notice            = 0;
    private        SpriteAI anim              = null;
    private        GameManager gameManager    = null;
    private        string   commentText       = "정찰 요원에게 걸려서 임무를 실패했네, 다음부턴 더 조심하게나."; // 이 AI에 의하여 게임이 오버됐을 때 뜨는 comment
    private static bool     isFound           = false;
    private static bool     isAINoticedPlayer = false;
    public  static bool     getIsFound        { get { return isFound; } } // 으으흠.
    public  static bool     getIsAINoticed    { get { return isFound; } } // 으흐음.




    #region 오브젝트
    //[Header("지금은 사용되지 않음")]
    //[SerializeField] private float      detectRange  = 1.0f;
    [Header("AI 가 찾을 오브젝트")]
    [SerializeField] private GameObject player       = null;
    [Header("AI의 탐지 범위")]
    [SerializeField] private GameObject maxDetectPos = null;
    [SerializeField] private GameObject minDetectPos = null;
    #endregion
    #endregion


    void Awake()
    {
        gameManager = GameManager.Instance;
        anim = FindObjectOfType<SpriteAI>();
        #region 에디터용 코드
#if UNITY_EDITOR
        CheckVar();
#endif
        #endregion
        SetCoord();
    }

    public void AILookUp()
    {
        LookForPlayer();
        NoticePlayer();
        ShowStack();
    }

    private void ShowStack()
    {
        switch (notice)
        {
            case 0:
                anim.AINoStack();
                return;
            //case 1:
            //    anim.AIOneStack();
            //    return;
            //case 1:
            //    anim.AITwoStack();
            //    return;
            case 1:
                anim.AIFullStack();
                return;
        }
    }

    void LookForPlayer()
    {
        #region 예전 코드
        // 이유: 사람 실제 시아는 앞을 제일 잘 봄
        // 코드: 반원 안에 들어오면 다 발견함
        // 결론: 기능이 사실적이지 않음
        // 망상: 삼각함수 각?
        // 결과: 맵은 채스판이고 탑뷰다아. 그대로 나두자아아
        // 이런: 시아가 좀 이상하네요...
        // 결국: 갈아 엎게 되었습니다.

        //if (Vector3.Distance(transform.position, player.transform.position) > detectRange)
        //{
        //    if(notice >= 0)
        //    {
        //        --notice;
        //    }
        //    isFound = false;
        //}
        //else
        //{
        //    ++notice;
        //    isFound = true;
        //}
        #endregion
        bool isAtSight = false;
        bool isAtSameX = (player.transform.position.x < (transform.position.x + 0.25f)) && (player.transform.position.x > (transform.position.x - 0.25f));


        #region 임시 코드. 만약 ㄱ 자로 순찰을 도는 친구가 생긴다면 나중에 수정해야함
        switch (MoveAI.getIsYBigger)
        {
            case true:
                isAtSight = (player.transform.position.y <= maxY) && (player.transform.position.y > transform.position.y) && isAtSameX;
                break;

            case false:
                isAtSight = (player.transform.position.y >= minY) && (player.transform.position.y < transform.position.y) && isAtSameX;
                break;
        }

        if(isAtSight)
        {
            //Debug.Log("시아 안");
            notice = (notice == 3) ? 3 : ++notice;
            isFound = true;
        }
        else
        {
            //Debug.Log("시아 밖");
            notice = (notice == 0) ? 0 : --notice;
            isFound = false;
        }

        #endregion

    }

    void NoticePlayer()
    {
        if(notice == 2)
        {
            isAINoticedPlayer = true;
            notice = 0;
            gameManager.SetComment(commentText);
            gameManager.SetGameOver(true);
        }
    }

    /// <summary>
    /// 변수에 오브젝트 좌표 저장
    /// </summary>
    private void SetCoord()
    {
        minX = minDetectPos.transform.position.x;
        minY = minDetectPos.transform.position.y;
        maxX = maxDetectPos.transform.position.x;
        maxY = maxDetectPos.transform.position.y;
    }

#if UNITY_EDITOR
    private void CheckVar()
    {
        if (player == null)
        {
            DisplayError("AI 오류", "AI 가 찾을 플레이어가 없습니다");
        }
        if (anim == null)
        {
            DisplayError("AI 에니메이션 오류", "SpriteAI 스크립트가 AI에 추가되어있는지 확인하세요.");
        }
        bool isNull = (maxDetectPos == null) && (minDetectPos == null);
        if (isNull)
        {
            DisplayError("탐지 오류.", "AI가 탐지할 곳이 없습니다.");
        }
    }

    /// <summary>
    /// 에러 팝업창을 표시하는 함수
    /// </summary>
    /// <param name="title">제목</param>
    /// <param name="info">내용</param>
    /// <param name="stopEditor">에디터 중지 여부</param>
    private void DisplayError(string title, string info, bool stopEditor = true)
    {
        UnityEditor.EditorUtility.DisplayDialog(title, info, "확인");

        if(stopEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
#endif

}
