using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private Text text = null;

    private GameManager gameManager = null;

    private void Start()
    {
        gameManager = GameManager.Instance;
        SetText();
    }
    void SetText()
    {
        if(gameManager.GetIsPhotoDone())
        {
            text.text = "GameClear";
        }
        else if(gameManager.GetGameOver())
        {
            text.text = "GameOver";
        }
    }
}
