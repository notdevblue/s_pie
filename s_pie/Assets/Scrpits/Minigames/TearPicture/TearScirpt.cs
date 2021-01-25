using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearScirpt : MonoBehaviour
{
    private float waitTime = 0.1f;
    private float clearTime = 5f;

    [SerializeField]
    private int firstDirection = 1;
    [SerializeField]
    private int secondDirection = 2;
    [SerializeField]
    private int thirdDirection = 3;
    [SerializeField]
    private int forthDirection = 4;

    [SerializeField]
    private Vector2 pasteMousePosition = Vector2.zero;
    [SerializeField]
    private Vector2 currentMousePosition = Vector2.zero;
    [SerializeField]
    private bool mouseMovedUp = false;
    [SerializeField]
    private bool mouseMovedDown = false;
    [SerializeField]
    private bool mouseMovedLeft = false;
    [SerializeField]
    private bool mouseMovedRight = false;

    private bool canMouseObserved = true;

    private bool gameClear = false;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeCheck());
        SetDirection();
    }
    // Update is called once per frame
    void Update()
    {
        SetMousePosition();
        StartCoroutine(SetPasteMousePosition());
        MouseMoveCheck();
        CheckMouseMove();
        CheckClear();

    }
    private IEnumerator TimeCheck()
    {
        yield return new WaitForSeconds(clearTime);
        // 임무 실패
        gameOver = true;
    }
    private IEnumerator SetPasteMousePosition()
    {
        if (canMouseObserved)
        {
            pasteMousePosition = currentMousePosition;
            canMouseObserved = false;

            yield return new WaitForSeconds(waitTime);

            canMouseObserved = true;
        }
    }
    private void SetDirection()
    {
        firstDirection = 1;
        secondDirection = 2;
        thirdDirection = 3;
        forthDirection = 4;
    }
    private void MouseMoveCheck()
    {
        if (Input.GetMouseButton(0))
        {
            if (currentMousePosition.y > pasteMousePosition.y)
            {
                // 마우스가 위쪽으로 이동한 경우
                mouseMovedUp = true;
            }
            if (currentMousePosition.y < pasteMousePosition.y)
            {
                // 마우스가 아래쪽으로 이동한 경우
                mouseMovedDown = true;

            }
            if (currentMousePosition.x > pasteMousePosition.x)
            {
                // 마우스가 오른쪽으로 이동한 경우
                mouseMovedRight = true;
            }
            if (currentMousePosition.x < pasteMousePosition.x)
            {
                // 마우스가 왼쪽으로 이동한 경우
                mouseMovedLeft = true;
            }
        }
    }
    void SetMousePosition()
    {
        currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void CheckMouseMove()
    {
        if (thirdDirection == 0)
        {
            switch (forthDirection)
            {
                case 1:
                    // 위
                    if (mouseMovedUp)
                    {
                        forthDirection = 0;
                    }
                    break;
                case 2:
                    // 아래
                    if (mouseMovedDown)
                    {
                        forthDirection = 0;
                    }
                    break;
                case 3:
                    // 오른쪽
                    if (mouseMovedRight)
                    {
                        forthDirection = 0;
                    }
                    break;
                case 4:
                    // 왼쪽
                    if (mouseMovedLeft)
                    {
                        forthDirection = 0;
                    }
                    break;
            }
        }
        if (secondDirection == 0)
        {
            switch (thirdDirection)
            {
                case 1:
                    // 위
                    if (mouseMovedUp)
                    {
                        thirdDirection = 0;
                    }
                    break;
                case 2:
                    // 아래
                    if (mouseMovedDown)
                    {
                        thirdDirection = 0;
                    }
                    break;
                case 3:
                    // 오른쪽
                    if (mouseMovedRight)
                    {
                        thirdDirection = 0;
                    }
                    break;
                case 4:
                    // 왼쪽
                    if (mouseMovedLeft)
                    {
                        thirdDirection = 0;
                    }
                    break;
            }
        }
        if (firstDirection == 0)
        {
            switch (secondDirection)
            {
                case 1:
                    // 위
                    if (mouseMovedUp)
                    {
                        secondDirection = 0;
                    }
                    break;
                case 2:
                    // 아래
                    if (mouseMovedDown)
                    {
                        secondDirection = 0;
                    }
                    break;
                case 3:
                    // 오른쪽
                    if (mouseMovedRight)
                    {
                        secondDirection = 0;
                    }
                    break;
                case 4:
                    // 왼쪽
                    if (mouseMovedLeft)
                    {
                        secondDirection = 0;
                    }
                    break;
            }
        }
            switch (firstDirection)
            {
                case 1:
                    // 위
                    if (mouseMovedUp)
                    {
                        firstDirection = 0;
                    }
                    break;
                case 2:
                    // 아래
                    if (mouseMovedDown)
                    {
                        firstDirection = 0;
                    }
                    break;
                case 3:
                    // 오른쪽
                    if (mouseMovedRight)
                    {
                        firstDirection = 0;
                    }
                    break;
                case 4:
                    // 왼쪽
                    if (mouseMovedLeft)
                    {
                        firstDirection = 0;
                    }
                    break;
            }

    }
    private void CheckClear()
    {
        bool a = (firstDirection == 0 && secondDirection == 0 && thirdDirection == 0 && forthDirection == 0);
        if(a)
            gameClear = true;
    }
    public bool GetGameClear()
    {
        return gameClear;
    }
    public bool GetGameOver()
    {
        return gameOver;
    }
}
