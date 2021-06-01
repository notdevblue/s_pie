using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    private float comeBackWait = 10f;
    private GameManager gameManager = null;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        StartCoroutine(IE_GoToMenu());
    }
    private IEnumerator IE_GoToMenu()
    {
        yield return new WaitForSeconds(comeBackWait);
        gameManager.SetIsPhotoDone(false);
        gameManager.SetGameOver(false);
        gameManager.SetCanGameDoneLoad(true);
        SceneManager.LoadScene("MainMenu");
    }
}
