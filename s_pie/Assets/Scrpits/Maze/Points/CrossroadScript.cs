using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossroadScript : MonoBehaviour
{

    private Vector2 currentPosition = Vector2.zero;

    private MazeManager mazeManager = null;
    private PlayerScript playerScript = null;
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private CrossroadScript C_leftScript = null;

    [SerializeField]
    private CrossroadScript C_rightScript = null;

    [SerializeField]
    private CrossroadScript C_upScript = null;

    [SerializeField]
    private CrossroadScript C_downScript = null;

    [SerializeField]
    private bool crossRoadIsLeft = false;
    [SerializeField]
    private bool crossRoadIsRight = false;
    [SerializeField]
    private bool crossRoadIsUp = false;
    [SerializeField]
    private bool crossRoadIsDown = false;

    [SerializeField]
    private bool canMoveLeft = false;
    [SerializeField]
    private bool canMoveRight = false;
    [SerializeField]
    private bool canMoveUp = false;
    [SerializeField]
    private bool canMoveDown = false;

    [SerializeField]
    private int unitId = 0;
    [SerializeField]
    private float playerDistance = 0f;

    private bool canGoalScriptSet = true;
    private bool canFuseboxScriptSet = true;
    private bool canPlayerPositionSet = true;

    // Start is called before the first frame update
    void Start()
    {
        mazeManager = FindObjectOfType<MazeManager>();
        playerScript = FindObjectOfType<PlayerScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = null;

        NumSet();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.localPosition;

        playerDistance = Vector2.Distance(currentPosition, playerScript.GetCurrentPosition());

        IsGoalScript();
        IsFirstPosition();
        IsFuseboxScript();
        crossRoadIsSet();
        CanMoveCheck();

        transform.localPosition = currentPosition;
    }
    void CanMoveCheck()
    {
        if (crossRoadIsLeft)
                canMoveLeft = true;

        if (crossRoadIsRight)
                canMoveRight = true;

        if (crossRoadIsUp)
                canMoveUp = true;

        if (crossRoadIsDown)
                canMoveDown = true;
    }
    public bool GetCanMoveLeft()
    {
        return canMoveLeft;
    }
    public bool GetCanMoveRight()
    {
        return canMoveRight;
    }
    public bool GetCanMoveUp()
    {
        return canMoveUp;
    }
    public bool GetCanMoveDown()
    {
        return canMoveDown;
    }
    public bool GetCrossroadIsLeft()
    {
        return crossRoadIsLeft;
    }
    public bool GetCrossroadIsRight()
    {
        return crossRoadIsRight;
    }
    public bool GetCrossroadIsUp()
    {
        return crossRoadIsUp;
    }
    public bool GetCrossroadIsDown()
    {
        return crossRoadIsDown;
    }
    public CrossroadScript GetLeftCrossroadScript()
    {
        return C_leftScript;
    }
    public CrossroadScript GetRightCrossroadScript()
    {
        return C_rightScript;
    }
    public CrossroadScript GetUpCrossroadScript()
    {
        return C_upScript;
    }
    public CrossroadScript GetDownCrossroadScript()
    {
        return C_downScript;
    }
    void crossRoadIsSet()
    {
        if (C_leftScript == null)
            crossRoadIsLeft = false;
        else if (C_leftScript != null)
            crossRoadIsLeft = true;

        if (C_rightScript == null)
            crossRoadIsRight = false;
        else if (C_rightScript != null)
            crossRoadIsRight = true;

        if (C_upScript == null)
            crossRoadIsUp = false;
        else if (C_upScript != null)
            crossRoadIsUp = true;

        if (C_downScript == null)
            crossRoadIsDown = false;
        else if (C_downScript != null)
            crossRoadIsDown = true;
    }
    void NumSet()
    {
        int a;
        a = mazeManager.GetCrossroadScriptNum();
        a++;
        unitId = a;
        mazeManager.SetCrossroadScriptNum(a);
    }
    void IsFirstPosition()
    {
        if(unitId == mazeManager.GetPlayerPositionId() && canPlayerPositionSet)
        {
            FirstPositionSet();
        }
    }
    void IsGoalScript()
    {
        bool fusebox = (mazeManager.GetComeFuseboxNum() >= 3);
        //Debug.Log(gameManager.GetGoalScriptId());
        if (unitId == mazeManager.GetGoalScriptId() && canGoalScriptSet && fusebox)
        {
            GoalScript();
        }
    }
    void IsFuseboxScript()
    {
        bool fuseId = (mazeManager.GetFuseboxId1() == unitId || mazeManager.GetFuseboxId2() == unitId || mazeManager.GetFuseboxId3() == unitId);
        if(fuseId && canFuseboxScriptSet)
        {
            FuseboxScript();
        }
    }
    void FirstPositionSet()
    {
        canPlayerPositionSet = false;
        gameObject.AddComponent<PlayerPositionScript>();
    }
    void GoalScript()
    {
        canGoalScriptSet = false;
        gameObject.AddComponent<GoalScript>();
    }
    void FuseboxScript()
    {
        canFuseboxScriptSet = false;
        gameObject.AddComponent<FuseboxScript>();
    }
    public void SetCurrentPosition(Vector2 a)
    {
        currentPosition = a;
    }
    public Vector2 GetCurretnPosition()
    {
        return currentPosition;
    }
}
