using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 클래스 이름이 좀 애매하긴 한데,
/// 플레이어를 탐색하는 용도의 클래스 입니다.
/// </summary>
public class PartrolAI : MonoBehaviour
{
    public static bool isFound = false; // 좋지 못한 코드
    private bool isAINoticedPlayer = false;
    private int notice = 0;

    

    [SerializeField] private GameObject player;

    [Header("플레이어를 인식할 거리")]
    [SerializeField] private float detectRange = 1.0f;

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

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            LookForPlayer();
            NoticePlayer();
        }
    }

    void LookForPlayer()
    {
        if(Vector3.Distance(transform.position, player.transform.position) > detectRange)
        {
            Debug.Log("플레이어 발견되지 않음");
            ++notice;
            isFound = false;
        }
        else
        {
            Debug.Log("플레이어 발견");
            --notice;
            isFound = true;
        }
    }
    void NoticePlayer()
    {
        if(notice == 3)
        {
            isAINoticedPlayer = true;
            Debug.Log("AI 가 플레이어를 발견함");
        }
    }

}
