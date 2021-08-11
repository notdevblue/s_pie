using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtOliberMenu : OnFocus
{
    [Header("조명 에니메이터")]
    public Animator animator = null;

    public override void Focus()
    {
        animator.SetTrigger("On");
    }

    void Update()
    {
        // 메뉴에 도착하면 불을 킴
        if (FocusManager.IsFocus(FocusManager.FocusTarget.Oliber))
        {
            Focus();
            this.enabled = false;
        }
    }
}
