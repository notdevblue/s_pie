using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAI : MonoBehaviour
{
    #region 변수
    [Header("AI 위에 발각 스택 알려주는 오브젝트")]
    [SerializeField] private GameObject clock = null;
                     private Animator    anim = null;
                     private Animator   cAnim = null;
    #endregion


    private void Awake()
    {
        cAnim = clock.GetComponent<Animator>();
        anim = GetComponent<Animator>();
        #region 에디터용
#if UNITY_EDITOR
        if (anim == null)
        {
            UnityEditor.EditorUtility.DisplayDialog("뭔가가 잘못됬어요...", "에니메이터를 찾을 수 없습니다.", "확인");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        if (cAnim == null)
        {
            UnityEditor.EditorUtility.DisplayDialog("뭔가가 잘못됬어요...", "스탑워치에서 에니메이터를 찾을 수 없습니다.", "확인");
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif
        #endregion
    }

    #region AI 이동
    public void AIUp()
    {
        anim.Play("Stage1AIUp");
    }
    public void AIDown()
    {
        anim.Play("Stage1AIDown");
    }
    #endregion

    #region 발각스택
    public void AINoStack()
    {
        cAnim.Play("AINoStack");
    }
    public void AIOneStack()
    {
        cAnim.Play("AIOneStack 1");
    }
    public void AITwoStack()
    {
        cAnim.Play("AITwoStack 1");
    }
    public void AIFullStack()
    {
        cAnim.Play("AIFullStack");
    }
    #endregion
}
