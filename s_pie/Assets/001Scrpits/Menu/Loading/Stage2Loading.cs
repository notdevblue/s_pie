using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage2Loading : MonoBehaviour
{
    [SerializeField] private Slider prog;


    void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }

    private IEnumerator LoadAsyncOperation()
    {
        AsyncOperation stage = SceneManager.LoadSceneAsync("Stage2");

        while(stage.progress < 1)
        {
            prog.value = stage.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
