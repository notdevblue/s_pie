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

    private int limitStar1 = 0; // 이 숫자 이상으로 턴을 남겼으면 별 한개.
    private int limitStar2 = 0;
    private int limitStar3 = 0;

    private void Start()
    {
        gameManager = GameManager.Instance;

        SetText();
        CheckStars();
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
            titleText.text = "GameClear";
        }
        else if(gameManager.GetGameOver())
        {
            titleText.text = "GameOver";
        }
    }
    private void CheckStars()
    {
        // 여기서 별들 개수 체크, 소환
        if(gameManager.GetWasteTurn() >= limitStar1)
        {
            Instantiate(star, star1Position);

            if (gameManager.GetWasteTurn() >= limitStar2)
            {
                Instantiate(star, star2Position);

                if (gameManager.GetWasteTurn() >= limitStar3)
                {
                    Instantiate(star, star3Position);
                }
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
