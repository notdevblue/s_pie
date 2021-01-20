using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager UM;
    void Awake() => UM = this;

    //변수 선언
    public string curBtn; // awl = 송곳, Thur = 츄르, Cat_01 = 고양이1, Cat_02 = 고양이2, EmptyBox = 빈상자, 6 = 
    bool active;
    public Button interactionBtn;

    public void SetInteractionBtn(string index, bool _active)
    {
        curBtn = index;
        active = _active;
        interactionBtn.GetComponent<Button>().interactable = active;
    }

    public void ClickInteractionBtn()
    {
        // 송곳
        if (curBtn == "Awl")
        {
            Debug.Log("송곳먹음");
        }

        // 츄르
        else if (curBtn == "Thur")
        {
            //TODO:상호작용2
        }

        // 고양이1
        else if (curBtn == "Cat_01")
        {
            //TODO:상호작용2
        }

        // 고양이2
        else if (curBtn == "Cat_02")
        {
            //TODO:상호작용2
        }

        else if (curBtn == "EmptyBox")
        {
            //TODO:상호작용2
        }

    }

}
