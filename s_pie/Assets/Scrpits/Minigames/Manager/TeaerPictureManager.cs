using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaerPictureManager : MonoBehaviour
{
    private TearScirpt tearScript = null;
    [SerializeField]
    private bool gameClear = false;
    [SerializeField]
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        tearScript = FindObjectOfType<TearScirpt>();
    }

    // Update is called once per frame
    void Update()
    {
        ClearSet();
        ClearCheck();
    }
    void ClearSet()
    {
        gameClear = tearScript.GetGameClear();
        gameOver = tearScript.GetGameOver();
    }
    void ClearCheck()
    {
        if(gameClear)
        {
            // 클리어 했을 시의 상황
            Destroy(gameObject);
        }
        if(gameOver)
        {
            // 클리어 실패했을 시의 상황
            Destroy(gameObject);
        }
    }
}
