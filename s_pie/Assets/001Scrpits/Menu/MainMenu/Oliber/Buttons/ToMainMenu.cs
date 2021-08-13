using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMainMenu : Selectable
{
    [Header("조명 에니메이터")]
    public Animator animator = null;

    public override void OnCursorLeft()
    {
        // TODO : 에니메이션
    }

    public override void OnCursorUp()
    {
        
    }

    public override void OnSelected()
    {
        animator.SetTrigger("Off"); // 조명을 끔, MenuLightsOffState 가 알아서 카메라, Focus 설정해 줌
    }
}
