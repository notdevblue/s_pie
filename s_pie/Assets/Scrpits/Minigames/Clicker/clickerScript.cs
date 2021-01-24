using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickerScript : MonoBehaviour
{
    [SerializeField]
    private Canvas mainCanvas = null;
    private ClickerManager clickerManager = null;
    private void Start()
    {
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
        else if(clickerManager.GetGameIsOver())
        {
            // 미니게임 실패시의 상황
            Destroy(gameObject);
        }
    }
}
