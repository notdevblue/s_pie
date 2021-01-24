using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager : MonoBehaviour
{ 
    private int break1 = 6; // 살짝 금감
    private int break2 = 3; // 많이 금감

    private float clickTime = 300.5f;

    [SerializeField]
    private bool gameIsOver = false;
    // gameIsOver가 ture가 될시 게임오버 혹은 그전의 화면으로 돌아가고 패널티 부여
    [SerializeField]
    private bool gameIsClear = false;
    // gameIsClear가 true가 될시 곧바로 이전의 화면으로 넘어가도록 할것.

    private void Start()
    {
        StartCoroutine(GameOverCheck());
    }
    public void SetGameIsOver(bool a)
    {
        gameIsOver = a;
    }
    public bool GetGameIsOver()
    {
        return gameIsOver;
    }
    public void SetGameIsClear(bool a)
    {
        gameIsClear = a;
    }
    public bool GetGameIsClear()
    {
        return gameIsClear;
    }
    public int GetBreak1()
    {
        return break1;
    }
    public int GetBreak2()
    {
        return break2;
    }
    IEnumerator GameOverCheck()
    {
        yield return new WaitForSeconds(clickTime);
        gameIsOver = true;
    }

}
