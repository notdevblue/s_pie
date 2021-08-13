using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : Selectable
{
    [Header("로드할 씬 이름")]
    [SerializeField] private string sceneName = "";

    public override void OnCursorLeft()
    {
        
    }

    public override void OnCursorUp()
    {
        
    }

    public override void OnSelected()
    {
        if (sceneName != "")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
