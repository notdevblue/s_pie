using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private MoveAI[] moveAI = null; //AI가 여러개 일수도 있기 때문에 배열로 만듬

    private int turn = 0; //현재 턴이 몇인지 확인
    public bool playerTurn = true; //현재 플레이어 턴인지 확인

    private void Awake()
    {
        moveAI = FindObjectsOfType<MoveAI>();
    }

    public void EndPlayerTurn(int addTurn/*플레이어가 몇턴을 사용했는지 받아옴*/) //플레이어 턴
    {
        playerTurn = false;
        turn += addTurn;
        Debug.Log(turn + "턴 지남");
        AITurn(addTurn); //AI턴으로 넘어감
    }

    private void AITurn(int aITurn/*플레이어가 사용한 턴 만큼 AI가 이동함*/) //AI턴
    {
        #region AI가 움직이는 코드
        for (int i = 0; i < aITurn; i++)
        {
            for (int aINum = 0; aINum < moveAI.Length; aINum++)
            {
                moveAI[aINum].AIMove();
            }
        }
        #endregion

        playerTurn = true;
    }
}
