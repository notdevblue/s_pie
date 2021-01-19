using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 우앱: 플레이어가 타일 뒤로 들어가는 문제 때문에 Vector3 로 바꿨슴

    //이동 관련 변수
    [SerializeField] private float distance = 1f;  //이동거리
    [SerializeField] private Vector3 limitMax = Vector3.zero; //X 제한
    [SerializeField] private Vector3 limitMin = Vector3.zero; //Y 제한
    private Vector3 targetPosition = Vector3.zero; //이동할 좌표

    private TurnManager turnManager = null; //플레이어 턴인지 아닌지 확인하기 위해서 만듬

    private void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();
        #region 널레퍼런스 방지용 코드 (유니티 에디터에서만 실행됨)
#if UNITY_EDITOR
        NullCheck();
#endif
        #endregion
    }


    #region 널레퍼런스 방지용 코드 (유니티 에디터에서만 실행됨)
#if UNITY_EDITOR
    void NullCheck()
    {
        if(turnManager == null)
        {
            UnityEditor.EditorUtility.DisplayDialog("턴 메니저 오류", "턴 메니저가 씬에서 발견되지 않았습니다.", "확인");
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
#endif
    #endregion
    #region 영상용 코드 (WASD 움직임)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            ClickUp();
        if (Input.GetKeyDown(KeyCode.S))
            ClickDown();
        if (Input.GetKeyDown(KeyCode.A))
            ClickLeft();
        if (Input.GetKeyDown(KeyCode.D))
            ClickRight();
    }
    #endregion


    public void ClickUp() //위에 있는 버튼을 눌렀을때
    {
        if (turnManager.playerTurn == true) //플레이어 턴 인지 확인
        {
            if (transform.localPosition.y < limitMax.y) //오브젝트 앞에 길이 있는지 검사
            {
                targetPosition = transform.localPosition; // 현재 좌표를 받아옴
                targetPosition.y += distance; // 이동할 좌표의 y축을 계산
                transform.localPosition = targetPosition; // 계산한 좌표로 이동
                turnManager.EndPlayerTurn(1); // 플레이어 턴 종료
            }
        }
    }

    public void ClickDown() //아레 있는 버튼을 눌렀을때
    {
        if (turnManager.playerTurn == true)
        {
            if (transform.localPosition.y > limitMin.y)
            {
                targetPosition = transform.localPosition;
                targetPosition.y -= distance;
                transform.localPosition = targetPosition;
                turnManager.EndPlayerTurn(1);
            }
        }
    }

    public void ClickRight() //오른쪽에 있는 버튼을 눌렀을때
    {
        if (turnManager.playerTurn == true)
        {
            if (transform.localPosition.x < limitMax.x) 
            {
                targetPosition = transform.localPosition; 
                targetPosition.x += distance; // 이동할 좌표의 x축을 계산
                transform.localPosition = targetPosition;
                turnManager.EndPlayerTurn(1);
            }
        }
    }

    public void ClickLeft() //왼쪽에 있는 버튼을 눌렀을때
    {
        if (turnManager.playerTurn == true)
        {
            if (transform.localPosition.x > limitMin.x) 
            {
                targetPosition = transform.localPosition; 
                targetPosition.x -= distance;
                transform.localPosition = targetPosition;
                turnManager.EndPlayerTurn(1);
            }
        }
    }
}
