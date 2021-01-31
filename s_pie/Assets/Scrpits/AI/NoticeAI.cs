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
    private        float       maxX              = 0.0f;
    private        float       minX              = 0.0f;
    private        float       maxY              = 0.0f;
    private        float       minY              = 0.0f;
    private        int         notice            = 0;
    private        SpriteAI    anim              = null;
    private        GameManager gameManager       = null;
    private        PlayerMove  playerMove        = null;
    private        string      commentText       = "발각됬어, 빨리 탈출해."; // 이 AI에 의하여 게임이 오버됐을 때 뜨는 comment
    private static bool        isFound           = false;
    private static bool        isAINoticedPlayer = false;
    public  static bool        getIsFound        { get { return isFound; } } // 으으흠.
    public  static bool        getIsAINoticed    { get { return isFound; } } // 으흐음.



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
        playerMove = FindObjectOfType<PlayerMove>();
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
    public bool CheckFirst()
    {
        return CheckPlayer(player.transform.position);
    }
    private bool CheckPlayer(Vector2 playerPos)
    {
        bool isAtSight;
        bool isAtSameX = (playerPos.x < (transform.position.x + 0.5f)) && (playerPos.x > (transform.position.x - 0.5f));


        //Debug.Log(MoveAI.getIsYBigger);

        if (MoveAI.getIsYBigger)
        {
            isAtSight = (playerPos.y <= maxY) && (playerPos.y > transform.position.y) && isAtSameX;
        }
        else
        {
            isAtSight = (playerPos.y >= minY) && (playerPos.y < transform.position.y) && isAtSameX;
        }
        return isAtSight;
    }

    void LookForPlayer()
    {
        Debug.Log($"{transform.position} AI 위치 값");
        Debug.Log($"{playerMove.getPlayerHeading} 플레이어 목표 값");
        bool isAtHeading = CheckPlayer(playerMove.getPlayerHeading);

        Debug.Log($"{player.transform.position} 플레이어 현재 값");
        bool isAtSight   = CheckPlayer(player.transform.position);

        if(isAtSight || isAtHeading)
        {
            Debug.Log("시아 안");
            notice = (notice == 3) ? 3 : ++notice;
            isFound = true;
        }
        else
        {
            Debug.Log("시아 밖");
            notice = (notice == 0) ? 0 : --notice;
            isFound = false;
        }
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
