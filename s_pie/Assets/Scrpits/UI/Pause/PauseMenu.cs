using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private                Canvas pauseCanv = null;
    [SerializeField] private                Canvas uiCanvas  = null;
    [SerializeField] private UnityEngine.UI.Button yesButton = null;
    [SerializeField] private UnityEngine.UI.Button noButton  = null;
    [SerializeField] private UnityEngine.UI.Text   askText   = null;
                     private                bool   retMain   = false;
                     private                bool   replay    = false;

    private void Awake()
    {
        #region 유니티 에디터에서만 실행되는 널체크
#if UNITY_EDITOR
        if ((pauseCanv == null) || (uiCanvas == null))
        {
            UnityEditor.EditorUtility.DisplayDialog("일시정시 스크립트 오류", "켄버스가 할당되지 않았습니다.", "확인");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        if((yesButton == null) || (noButton == null))
        {
            UnityEditor.EditorUtility.DisplayDialog("일시정시 스크립트 오류", "버튼이 할당되지 않았습니다.", "확인");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        if (askText == null)
        {
            UnityEditor.EditorUtility.DisplayDialog("일시정시 스크립트 오류", "텍스트가 할당되지 않았습니다.", "확인");
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif
        #endregion

        yesButton.gameObject.SetActive(false);
        noButton .gameObject.SetActive(false);
        askText  .gameObject.SetActive(false);
        pauseCanv.gameObject.SetActive(false);
    }




    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    // TODO : 키보드 입력 막아야 함
    public void Pause()
    {
        pauseCanv.gameObject.SetActive(!pauseCanv.isActiveAndEnabled);
        uiCanvas .gameObject.SetActive(!uiCanvas.isActiveAndEnabled);
    }

    public void AskRestart()
    {
        yesButton.gameObject.SetActive(true);
        noButton .gameObject.SetActive(true);
        askText  .gameObject.SetActive(true);
        askText.text = "임무를 다시 시작할까요?";
        replay       = true;
    }

    public void AskReturnMain()
    {
        yesButton.gameObject.SetActive(true);
        noButton .gameObject.SetActive(true);
        askText  .gameObject.SetActive(true);
        askText.text = "메인 화면으로 돌아갈까요?";
        retMain      = true;
    }

    public void No()
    {
        yesButton.gameObject.SetActive(false);
        noButton .gameObject.SetActive(false);
        askText  .gameObject.SetActive(false);
        retMain = false;
        replay  = false;
    }

    public void Yes()
    {
        if(retMain)
        {
            ReturnMain();
        }
        if(replay)
        {
            Restart();
        }
    }

    private void ReturnMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainLoad");
    }

    private void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name + "Load");
    }
}
