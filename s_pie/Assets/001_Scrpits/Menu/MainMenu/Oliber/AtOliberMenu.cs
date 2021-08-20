using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtOliberMenu : OnFocus
{
    [Header("조명 에니메이터")]
    public Animator animator = null;

    // TODO : 계속 켜지게 될 것
    public override void Focus()
    {
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "OliberLightsOff")
            animator.SetTrigger("On");
    }
    
    void Update()
    {
        // 메뉴에 도착하면 불을 킴
        if (FocusManager.IsFocus(FocusManager.FocusTarget.Oliber))
        {
            Focus();
        }
    }
}
