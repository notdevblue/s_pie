using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3 : Button1
{
    private void destroyTimeSet()
    {
        destroyTime = shutDownManager.GetButton3ClickTime();
    }
    public new void OnClickButton()
    {
        buttonClicked = true;
        shutDownManager.SetButton3Clicked(true);
        Destroy(gameObject);
    }
}
