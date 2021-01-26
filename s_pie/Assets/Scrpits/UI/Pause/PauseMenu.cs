using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas canv   = null;
                     private bool isActive = false;


    private void Awake()
    {
        #region 유니티 에디터에서만 실행되는 널체크
#if UNITY_EDITOR
        if (canv == null)
        {
            UnityEditor.EditorUtility.DisplayDialog("켄버스 오류", "일시정지 켄버스가 할당되지 않았습니다.", "확인");
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif
        #endregion


        canv.gameObject.SetActive(false);
    }




    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }


    public void Pause()
    {
        switch (isActive)
        {
            case true:
                canv.gameObject.SetActive(false);
                

                return;

            case false:
                canv.gameObject.SetActive(true);


                return;
        }
    }

}
