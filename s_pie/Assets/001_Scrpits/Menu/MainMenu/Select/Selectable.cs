using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Selectable : MonoBehaviour
{
    [HideInInspector] public int index; // SelectManager 에서 관리 위한 index

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SelectManager.ToggleSelected(index);
        OnCursorUp();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SelectManager.ToggleSelected(index);
        OnCursorLeft();
    }

    /// <summary>
    /// 마우스 포인터가 위에 있을 때
    /// </summary>
    abstract public void OnCursorUp();

    /// <summary>
    /// 마우스 포인터가 이것을 떠날 때
    /// </summary>
    abstract public void OnCursorLeft();

    /// <summary>
    /// 선택되었을 때
    /// </summary>
    abstract public void OnSelected();
}
