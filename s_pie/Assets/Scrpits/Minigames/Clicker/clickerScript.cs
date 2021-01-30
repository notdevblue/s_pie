using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickerScript : MonoBehaviour
{
    [SerializeField]
    private Canvas mainCanvas = null;
    private ClickerManager clickerManager = null;
    private GameManager gameManager = null;

    private string commentText = "카메라에게 자네의 얼굴이 찍혔잖나, 이거, 처리할 사진만 늘었구만. 앞으로는 조심하게.";
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
