using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickerScript : MonoBehaviour
{
    [SerializeField]
    private Canvas mainCanvas = null;
    private ClickerManager clickerManager = null;
    private GameManager gameManager = null;

    private string commentText = "카메라에 너가 찍혔어. 빨리 카메라 부수고 나와.";
    private void Start()
    {
        gameManager = GameManager.Instance;
        mainCanvas = FindObjectOfType<Canvas>();
        clickerManager = FindObjectOfType<ClickerManager>();
        transform.SetParent(mainCanvas.transform);
    }
    private void Update()
    {
        DestroyClicker();
    }
    public void DestroyClicker()
    {
        if(clickerManager.GetGameIsClear())
        {
            // 미니게임 클리어시의 상황
            Destroy(gameObject);
        }
        else if(gameManager.GetGameOver())
        {
            // 미니게임 실패시의 상황
            gameManager.SetComment(commentText);
            Destroy(gameObject);
        }
    }
}
