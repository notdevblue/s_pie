using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private Text titleText = null;
    [SerializeField]
    private Text wasteTurnText = null;
    [SerializeField]
    private Text comment = null;

    [SerializeField]
    private GameObject star = null;
    [SerializeField]
    private GameObject emptyStar = null;
    [SerializeField]
    private GameObject picture = null;

    [SerializeField]
    private Transform picture_TargetPosition = null;
    [SerializeField]
    private Transform star1Position = null;
    [SerializeField]
    private Transform star2Position = null;
    [SerializeField]
    private Transform star3Position = null;

    private GameManager gameManager = null;

    private float picture_Speed = 5f;

    private int starSpawned = 0;

    private int limitStar1 = 60; // 이 숫자 이상으로 턴을 남겼으면 별 한개.
    private int limitStar2 = 50;
    private int limitStar3 = 45;

    private void Start()
    {
        gameManager = GameManager.Instance;

        CheckStars();
        SetText();
    }
    private void Update()
    {
        picture.transform.localPosition = Vector3.MoveTowards(picture.transform.localPosition, picture_TargetPosition.
    transform.localPosition, picture_Speed * Time.deltaTime);
    }
    void SetText()
    {
        comment.text = gameManager.GetComment();
        picture.GetComponent<SpriteRenderer>().sprite = gameManager.GetGameOver_Picture();

        wasteTurnText.text = string.Format("\n  {0}분", gameManager.GetWasteTurn());
        if(gameManager.GetGameClear())
        {
            titleText.text = "임무 성공";
        }
        else if(gameManager.GetGameOver())
        {
            titleText.text = "임무 실패";
        }
        gameManager.SetGameClear(false);
        gameManager.SetGameOver(false);
    }
    private void CheckStars()
    {
        // 여기서 별들 개수 체크, 소환
        if (gameManager.GetGameClear())
        {
            if (gameManager.GetWasteTurn() <= limitStar1)
            {
                Instantiate(star, star1Position);

                if (gameManager.GetWasteTurn() <= limitStar2)
                {
                    Instantiate(star, star2Position);

                    if (gameManager.GetWasteTurn() <= limitStar3)
                    {
                        Instantiate(star, star3Position);
                    }
                    else
                    {
                        Instantiate(emptyStar, star1Position);
                    }
                }
                else
                {
                    Instantiate(emptyStar, star1Position);
                    Instantiate(emptyStar, star2Position);
                }
            }
            else
            {
                Instantiate(emptyStar, star1Position);
                Instantiate(emptyStar, star2Position);
                Instantiate(emptyStar, star3Position);
            }
        }
    }
    public int GetStarSpawned()
    {
        return starSpawned;
    }
    public void SetStarSpawned(int a)
    {
        starSpawned = a;
    }
}
