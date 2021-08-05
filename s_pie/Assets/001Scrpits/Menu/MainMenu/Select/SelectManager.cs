using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [Header("캐릭터 라이트, 왼쪽부터 넣어주세요.")]
    [SerializeField] private List<Animator> lights = new List<Animator>(); // 조명들

    static private SelectManager inst = null; // static 함수 접근 용

    private void Awake()
    {
        inst = this;
    }

    // 조명 키는 함수
    static public void LightOn(int index)
    {
        inst.lights[index].SetTrigger("On");
    }

    // 조명 끄는 함수
    static public void LightOff(int index)
    {
        inst.lights[index].SetTrigger("Off");
    }
}
