using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearScirpt : MonoBehaviour
{
    private float waitTime = 0.1f;

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

    [SerializeField]
    private Sprite tearedPicture = null;
    private string gameOver_Comment = "좋아, 임무 잘 해줬어. 이제 좀 익숙해졌지?\n그런데 고양이좀 데려오지 그랬냐...";

    private SpriteRenderer spriteRenderer = null;
    private AudioSource audi = null;

    private GameManager gameManager = null;

    private bool canMouseObserved = true;
    private float time = 0f;

    private bool gameClear = false;
    private bool gameOver = false;
    private bool pictureTeared = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        spriteRenderer = GetComponent<SpriteRenderer>();
        audi = GetComponent<AudioSource>();
        SetDirection();
        // 다이얼로그 시작
    }
    // Update is called once per frame
    void Update()
    {
        // if() // 다이얼 로그가 끝났을 때
        SetMousePosition();
        StartCoroutine(SetPasteMousePosition());
        MouseMoveCheck();
        CheckMouseMove();
        CheckClear();
        FadeIn();

    }
    private IEnumerator GameClearSet()
    {
        yield return new WaitForSeconds(4f);
        gameClear = true;
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
        if (a && !pictureTeared)
        {
            pictureTeared = true;
            spriteRenderer.sprite = tearedPicture;
            audi.Play();
            gameManager.SetComment(gameOver_Comment);
            gameManager.SetGameOver_Picture(tearedPicture);
            StartCoroutine(GameClearSet());
        }
    }
    private void FadeIn()
    {
        if(pictureTeared)
        {
            time += Time.deltaTime;
            spriteRenderer.color = new Color(1, 1, 1, time / 2);
        }
    }
    public bool GetMiniGameClear()
    {
        return gameClear;
    }
    public bool GetGameOver()
    {
        return gameOver;
    }
}
