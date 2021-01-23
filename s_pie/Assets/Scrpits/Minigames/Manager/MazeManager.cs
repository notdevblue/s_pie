using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField]
    private int turnningScriptNum = 0;
    [SerializeField]
    private int crossroadScriptNum = 0;
    [SerializeField]
    private int goalScriptNum = 0;

    [SerializeField]
    private int goalScriptId = 0;
    [SerializeField]
    private int playerPositionId = 0;
    [SerializeField]
    private int fuseboxId1 = 0;
    [SerializeField]
    private int fuseboxId2 = 0;
    [SerializeField]
    private int fuseboxId3 = 0;
    [SerializeField]
    private int comeFuseboxNum = 0;

    [SerializeField]
    private GameObject text = null;

    private static MazeManager instance;

    private Canvas canvas = null;

    [SerializeField]
    private bool isClear = false;

    private bool canClearTextSet = true;

    public static MazeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MazeManager>();
                if (instance == null)
                {
                    GameObject temp = new GameObject("MazeManager");
                    instance = temp.AddComponent<MazeManager>();
                }
            }
            return instance;
        }
    }
    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        SetGoalScriptId();
        fuseboxIdSet();
        SetPlayerPosition();
    }
    private void Update()
    {
        ClearCheck();
    }
    void fuseboxIdSet()
    {
        do
        {
            fuseboxId1 = Random.Range(1, crossroadScriptNum);
        } while (fuseboxId1 == goalScriptId || fuseboxId1 == playerPositionId);

        do
        {
            fuseboxId2 = Random.Range(1, crossroadScriptNum);
        } while (fuseboxId2 == goalScriptId || fuseboxId2 == playerPositionId || fuseboxId2 == fuseboxId1);

        do
        {
            fuseboxId3 = Random.Range(1, crossroadScriptNum);
        } while (fuseboxId3 == goalScriptId || fuseboxId3 == playerPositionId || fuseboxId3 == fuseboxId1 || fuseboxId3 == fuseboxId2);
    }
    void ClearCheck()
    {
        if(isClear && canClearTextSet)
        {
            canClearTextSet = false;
            Instantiate(text);
        }
    }
    void SetPlayerPosition()
    {
        do
        {
            playerPositionId = Random.Range(1, crossroadScriptNum);
        } while (playerPositionId == goalScriptId);
    }
    void  SetGoalScriptId()
    {
        goalScriptId = Random.Range(1, crossroadScriptNum);
    }
    public Canvas GetCanvas()
    {
        return canvas;
    }
    public void SetIsClear(bool a)
    {
        isClear = a;
    }
    public int GetFuseboxId1()
    {
        return fuseboxId1;
    }
    public int GetFuseboxId2()
    {
        return fuseboxId2;
    }
    public int GetFuseboxId3()
    {
        return fuseboxId3;
    }
    public int GetPlayerPositionId()
    {
        return playerPositionId;
    }
    public int GetGoalScriptId()
    {
        return goalScriptId;
    }
    public void SetTurnningScriptNum(int a)
    {
        turnningScriptNum = a;
    }
    public int GetTurnningScriptNum()
    {
        return turnningScriptNum;
    }
    public void SetCrossroadScriptNum(int a)
    {
        crossroadScriptNum = a;
    }
    public int GetCrossroadScriptNum()
    {
        return crossroadScriptNum;
    }
    public void SetGoalScriptNum(int a)
    {
        goalScriptNum = a;
    }
    public int GetGoalScriptNum()
    {
        return goalScriptNum;
    }
    public void SetComeFuseboxNum(int a)
    {
        comeFuseboxNum = a;
    }
    public int GetComeFuseboxNum()
    {
        return comeFuseboxNum;
    }
}
