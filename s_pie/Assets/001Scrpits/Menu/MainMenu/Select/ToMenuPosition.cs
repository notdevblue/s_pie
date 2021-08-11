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


    public override void OnCursorUp()
    {
        if (LightSelectManager.isSelected) return;
        LightSelectManager.LightOn(index); // 해당하는 인덱스의 조명을 킨다
    }

    public override void OnCursorLeft()
    {
        if (LightSelectManager.isSelected) return;
        LightSelectManager.LightOff(index); // 해당하는 인덱스의 조명을 끈다
    }

    public override void OnSelected()
    {
        // 해당 위치로 이동이 끝나면 카메라가 비추고 있는 메뉴 변수를 설정해줌
        CameraMover.MoveCamera(moveTo.position, duration, () => FocusManager.SetFocus(location));
    }
}
