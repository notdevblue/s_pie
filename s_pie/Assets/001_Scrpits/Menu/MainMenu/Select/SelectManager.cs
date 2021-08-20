using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager: MonoBehaviour
{
    [Header("선택 가능한 오브젝트들")]
    [SerializeField] private List<Selectable> selectables = new List<Selectable>(); // 선택 오브젝트
                     private List<bool>       selected    = new List<bool>();       // 조명 상태

    static private SelectManager inst = null; // static 함수 접근 용

    private void Awake()
    {
        inst = this;

        SetSelectablesIndex();
        SetSelectedStatusList();
    }

    #region 초기화

    // Selectable.index 설정
    private void SetSelectablesIndex()
    {
        for (int i = 0; i < selectables.Count; ++i)
        {
            selectables[i].index = i;
        }
    }

    // selected 리스트 초기화
    private void SetSelectedStatusList()
    {
        for (int count = 0; count < selectables.Count; ++count) // lights 리스트 크기와 같게 만듬
        {
            selected.Add(false);
        }
    }

    #endregion


    // 선택
    static public void ToggleSelected(int index)
    {
        inst.selected[index] = !inst.selected[index];
    }

    /// <summary>
    /// 선택 함수
    /// </summary>
    static public void Select()
    {
        int idx = inst.GetCurrentSelected();
        
        if (idx != -1)
        {
            inst.selectables[idx].OnSelected();
        }
    }

    /// <summary>
    /// 현제 선택된 매뉴의 인덱스를 가져옵니다.
    /// </summary>
    /// <returns>조명 켜져있는 것의 인덱스.<br></br>없는 경우 -1</returns>
    private int GetCurrentSelected()
    {
        for (int i = 0; i < selected.Count; ++i)
        {
            if (selected[i]) // 켜져있다면 인덱스 반환
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// Selectables 오브젝트의 수를 가져옵니다
    /// </summary>
    /// <returns>Count of </returns>
    static public int GetSelectableObjectCount()
    {
        return inst.selectables.Count;
    }
}
