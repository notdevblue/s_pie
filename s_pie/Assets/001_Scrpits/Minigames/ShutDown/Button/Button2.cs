using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : Button1
{
    private void destroyTimeSet()
    {
        destroyTime = shutDownManager.GetButton2ClickTime();
    }
    public new void OnClickButton()
    {
        buttonClicked = true;
        shutDownManager.SetButton2Clicked(true);
        Destroy(gameObject);
    }
}
