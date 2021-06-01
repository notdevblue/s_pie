using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaerPictureManager : MonoBehaviour
{
    private TearScirpt tearScript = null;
    [SerializeField]
    private bool miniGameClear = false;
    [SerializeField]
    private bool gameOver = false;

    private GameManager gameManager = null;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
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
        miniGameClear = tearScript.GetMiniGameClear();
        gameOver = tearScript.GetGameOver();
    }
    void ClearCheck()
    {
        if(miniGameClear)
        {
            // 클리어 했을 시의 상황
            gameManager.SetPictureTeared(true);
            Destroy(gameObject);
        }
        if(gameOver)
        {
            // 클리어 실패했을 시의 상황
            gameManager.SetGameOver(true);
            Destroy(gameObject.GetComponentInParent<GameObject>());
        }
    }
}
