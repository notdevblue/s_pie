using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMenuPosition : Selectable
{
    [Header("카메라 이동 위치")]
    public Transform moveTo = null;

    [Header("이동할 위치 Enum")]
    public FocusManager.FocusTarget location;

    [Header("카메라 이동 시간")]
    public float duration = 2.0f;

    [Header("작동할 라이트")]
    public Animator cellingLight = null;

    public override void OnCursorUp()
    {
        if (cellingLight != null)
        {
            cellingLight.SetTrigger("On");
        }
    }

    public override void OnCursorLeft()
    {
        if (cellingLight != null)
        {
            cellingLight.SetTrigger("Off");
        }
    }

    public override void OnSelected()
    {
        // 해당 위치로 이동이 끝나면 카메라가 비추고 있는 메뉴 변수를 설정해줌
        CameraMover.MoveCamera(moveTo.position, duration, () => FocusManager.SetFocus(location));
    }
}
