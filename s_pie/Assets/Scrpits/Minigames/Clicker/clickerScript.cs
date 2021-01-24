using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickerScript : MonoBehaviour
{
    private ClickerManager clickerManager = null;
    private void Start()
    {
        clickerManager = FindObjectOfType<ClickerManager>();
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
