using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager UM;
    void Awake() => UM = this;

    //변수 선언
    public int curBtn; // 1 = 미정, 2 = 미정
    bool active;
    public Button interactionBtn;

    public void SetInteractionBtn(int index, bool _active)
    {
        curBtn = index;
        active = _active;
        interactionBtn.GetComponent<Button>().interactable = active;
    }

    public void ClickInteractionBtn()
    {
        // 1
        if (curBtn == 1)
        {
            //TODO:상호작용1
        }

        // 2
        else if (curBtn == 2)
        {
            //TODO:상호작용2
        }

    }

}
