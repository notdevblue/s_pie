using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusManager : MonoBehaviour
{
    // 카메라가 비추고 있는 메뉴
    // FocusTarget Enum 과 같은 순서가 됩니다.
    private bool[] targets;

    static private FocusManager inst = null; // static 함수 접근 용도

    private void Awake()
    {
        inst = this;

    }
    private void Start()
    {
        InitTargetsArray();
    }

    // bool[] targets 초기화
    private void InitTargetsArray()
    {
        targets = new bool[(int)FocusTarget.END_OF_ENUM];
        targets[(int)FocusTarget.Main] = true;

        // 처음에 카메라는 Main 을 비추고 있기 때문
        for (int i = 1; i < (int)FocusTarget.END_OF_ENUM; ++i)
        {
            targets[i] = false;
        }
    }

    public enum FocusTarget
    {
        Main = 0,
        Oliber,
        Bianca,
        Option,
        StageSelect,

        END_OF_ENUM // 반복문 에서 사용하기 위함
    }

    /// <summary>
    /// 카메라가 비추고 있는 메뉴를 알려줍니다.
    /// </summary>
    /// <param name="target">비추고 있는 메뉴</param>
    static public void SetFocus(FocusTarget target)
    {
        inst.targets[(int)target] = true;


        // 비추고 있지 않은 메뉴 변수들을 false 로 바꿈
        for (int i = 0; i < (int)FocusTarget.END_OF_ENUM; ++i)
        {
            if (i == (int)target) continue;

            inst.targets[i] = false;
        }

    }

    /// <summary>
    /// 카메라가 현재 해당되는 비추고 있는지 알려줍니다
    /// </summary>
    /// <param name="target">확인할 메뉴</param>
    /// <returns>bool[target]</returns>
    static public bool IsFocus(FocusTarget target)
    {
        return inst.targets[(int)target];
    }
}
