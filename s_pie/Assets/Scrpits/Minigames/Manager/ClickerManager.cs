using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickerManager : MonoBehaviour
{ 
    private int break1 = 6; // 살짝 금감
    private int break2 = 3; // 많이 금감

    private float clickTime = 3.5f;
    private float gameOverSoundPlayTime = 1f;

    [SerializeField]
    private AudioClip gameOverSound = null;

    private AudioSource audi = null;

    private GameManager gameManager = null;

    // gameIsOver가 ture가 될시 게임오버 혹은 그전의 화면으로 돌아가고 패널티 부여
    [SerializeField]
    private bool gameIsClear = false;
    // gameIsClear가 true가 될시 곧바로 이전의 화면으로 넘어가도록 할것.
    private bool canGameOverCheck = true;

    private void Start()
    {
        gameManager = GameManager.Instance;
        audi = gameObject.AddComponent<AudioSource>();
        canGameOverCheck = true;

        //dialog.instance.DialogStart(4);
    }
    private void Update()
    {
        //if (!dialog.instance.running && canGameOverCheck) // dialog.instance.running이 false값을 가진다면, 대화가 끝난 상태이다.
        //{
        //    StartCoroutine(GameOverCheck());
        //}
        if (canGameOverCheck)
        StartCoroutine(GameOverCheck());

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
        canGameOverCheck = false;
        yield return new WaitForSeconds(clickTime);
        audi.clip = gameOverSound;
        audi.Play();
        Debug.Log("a");
        yield return new WaitForSeconds(gameOverSoundPlayTime);
        gameManager.SetGameOver(true);
    }

}
