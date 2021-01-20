using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private MazeManager mazeManager = null;

    private CrossroadScript []crossRoadScript;

    [SerializeField]
    private Sprite goalSprite = null;
    [SerializeField]
    private Sprite FuseboxSprite = null;

    [SerializeField]
    private float[] crossRoadScriptDistance;

    [SerializeField]
    private CrossroadScript shortestCrossroadScript = null;


    private Vector2 currentPosition = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        mazeManager = FindObjectOfType<MazeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.localPosition;

        SetScripts();
        SetFirstDistances();
        SetDistance();
        MoveCheck();
        
        transform.localPosition = currentPosition;
    }
    public void FirstPositionSet(PlayerPositionScript a)
    {
        currentPosition = a.GetCurrentPosition();
        transform.localPosition = currentPosition;
    }
    public Sprite GetGoalSprite()
    {
        return goalSprite;
    }
    public Sprite GetFuseboxSprite()
    {
        return FuseboxSprite;
    }
    public Vector2 GetCurrentPosition()
    {
        return currentPosition;
    }
    public void SetCurrentPosition(Vector2 a)
    {
        currentPosition = a;
    }
    public void MoveCheck()
    {
        if (shortestCrossroadScript.GetCanMoveLeft())
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (shortestCrossroadScript.GetCrossroadIsLeft())
                    currentPosition = Vector2.MoveTowards(transform.localPosition, shortestCrossroadScript.GetLeftCrossroadScript().GetCurretnPosition(), 1000f * Time.deltaTime);
            }

        if (shortestCrossroadScript.GetCanMoveRight())
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (shortestCrossroadScript.GetCrossroadIsRight())
                    currentPosition = Vector2.MoveTowards(transform.localPosition, shortestCrossroadScript.GetRightCrossroadScript().GetCurretnPosition(), 1000f * Time.deltaTime);
            }

        if (shortestCrossroadScript.GetCanMoveUp())
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (shortestCrossroadScript.GetCrossroadIsUp())
                    currentPosition = Vector2.MoveTowards(transform.localPosition, shortestCrossroadScript.GetUpCrossroadScript().GetCurretnPosition(), 1000f * Time.deltaTime);
            }

        if (shortestCrossroadScript.GetCanMoveDown())
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (shortestCrossroadScript.GetCrossroadIsDown())
                    currentPosition = Vector2.MoveTowards(transform.localPosition, shortestCrossroadScript.GetDownCrossroadScript().GetCurretnPosition(), 1000f * Time.deltaTime);
            }
    }
    void SetScripts()
    {
        crossRoadScript = FindObjectsOfType(typeof(CrossroadScript)) as CrossroadScript[];
    }
    void SetFirstDistances()
    {
        crossRoadScriptDistance = new float[mazeManager.GetCrossroadScriptNum()];
    }
    void SetDistance()
    {
        float crossroadDistance = 10f;
        CrossroadScript b = null;
        for(int i = 0; i < mazeManager.GetCrossroadScriptNum(); i++)
        {
            crossRoadScriptDistance[i] = Vector2.Distance(crossRoadScript[i].GetCurretnPosition(), currentPosition);
            if(crossRoadScriptDistance[i] < crossroadDistance)
            {
                crossroadDistance = crossRoadScriptDistance[i];
                b = crossRoadScript[i];
            }
        }
        shortestCrossroadScript = b;

    }
}
