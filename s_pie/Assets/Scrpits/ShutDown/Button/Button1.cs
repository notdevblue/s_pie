using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    protected ShutDownManager shutDownManager = null;
    protected float destroyTime = 0f;
    protected bool buttonClicked = false;
    // Start is called before the first frame update
    protected void Start()
    {
        shutDownManager = FindObjectOfType<ShutDownManager>();
        transform.SetParent(shutDownManager.GetCanvas().transform);
        transform.localPosition = Vector2.zero;
        destroyTimeSet();
        StartCoroutine(DestroyCheck());
    }

    public void OnClickButton()
    {
        buttonClicked = true;
        shutDownManager.SetButton1Clicked(true);
        Destroy(gameObject);
    }
    private void destroyTimeSet()
    {
        destroyTime = shutDownManager.GetButton1ClickTime();
    }
    protected IEnumerator DestroyCheck()
    {
        yield return new WaitForSeconds(destroyTime);
        if(!buttonClicked)
        {
            shutDownManager.SetTimeOver(true);
            Destroy(gameObject);
        }    
    }
}
