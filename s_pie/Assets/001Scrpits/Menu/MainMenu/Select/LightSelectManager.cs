using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSelectManager: MonoBehaviour
{
    [Header("캐릭터 라이트, 왼쪽부터 넣어주세요.")]
    [SerializeField] private List<Animator>   lights = new List<Animator>();        // 조명들
    [SerializeField] private List<Selectable> selectables = new List<Selectable>(); // 선택 오브젝트
                     private List<bool>       isLightsOn = new List<bool>();        // 조명 상태

    static private LightSelectManager inst = null; // static 함수 접근 용

    static public bool isSelected = false; // 메뉴를 선택했는지


    private void Awake()
    {
        inst = this;

        SetLightsStatusList();
    }

    // isLightsOn 리스트 초기화
    private void SetLightsStatusList()
    {
        for (int count = 0; count < selectables.Count; ++count) // lights 리스트 크기와 같게 만듬
        {
            isLightsOn.Add(false);
        }
    }

    // 조명 키는 함수
    static public void LightOn(int index)
    {
        inst.isLightsOn[index] = true;

        if (inst.lights.Count > index)
        {
            inst.lights[index].SetTrigger("On");
        }
    }

    // 조명 끄는 함수
    static public void LightOff(int index)
    {
        inst.isLightsOn[index] = false;

        if (inst.lights.Count > index) // TODO : 고쳐야 함
        {
            inst.lights[index].SetTrigger("Off");
        }
    }

    /// <summary>
    /// 메뉴 선택 함수
    /// </summary>
    static public void Select()
    {
        int idx = inst.GetCurrentSelected();

        if (idx != -1)
        {
            inst.selectables[idx].OnSelected();
            isSelected = true;
        }
    }

    /// <summary>
    /// 현제 선택된 매뉴의 인덱스를 가져옵니다.
    /// </summary>
    /// <returns>조명 켜져있는 것의 인덱스.<br></br>없는 경우 -1</returns>
    private int GetCurrentSelected()
    {
        for (int i = 0; i < isLightsOn.Count; ++i)
        {
            if (isLightsOn[i]) // 켜져있다면 인덱스 반환
            {
                return i;
            }
        }

        return -1;
    }
}
