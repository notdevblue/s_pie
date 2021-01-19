using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDownManager : MonoBehaviour
{
    private float button1Time = 0f;
    private float button2Time = 0f;
    private float button3Time = 0f;

    private float button1ClickTime = 0f;
    private float button2ClickTime = 0f;
    private float button3ClickTime = 0f;

    private float button1Min = 3f;
    private float button1Max = 10f;

    private float button2Min = 10f;
    private float button2Max = 15f;

    private float button3Min = 15f;
    private float button3Max = 25f;

    private float button1ClickMin = 1f;
    private float button1ClickMax = 2f;

    private float button2ClickMin = 1f;
    private float button2ClickMax = 1.5f;

    private float button3ClickMin = 0.5f;
    private float button3ClickMax = 1.5f;

    [SerializeField]
    private bool button1Clicked = false;
    [SerializeField]
    private bool button2Clicked = false;
    [SerializeField]
    private bool button3Clicked = false;

    [SerializeField]
    private bool timeOver = false;
    [SerializeField]
    private bool gameClear = false;

    [SerializeField]
    private GameObject button1 = null;

    [SerializeField]
    private GameObject button2 = null;

    [SerializeField]
    private GameObject button3 = null;

    [SerializeField]
    private Canvas canvas = null;


    // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        button1Time = Random.Range(button1Min, button1Max);
        button2Time = Random.Range(button2Min, button2Max);
        button3Time = Random.Range(button3Min, button3Max);

        button1ClickTime = Random.Range(button1ClickMin, button1ClickMax);
        button2ClickTime = Random.Range(button2ClickMin, button2ClickMax);
        button3ClickTime = Random.Range(button3ClickMin, button3ClickMax);

        StartCoroutine(SpawnButton1());
        StartCoroutine(SpawnButton2());
        StartCoroutine(SpawnButton3());

    }

    // Update is called once per frame
    void Update()
    {
        ClearCheck();
    }
    private IEnumerator SpawnButton1()
    {
        yield return new WaitForSeconds(button1Time);
        Instantiate(button1);
    }
    private IEnumerator SpawnButton2()
    {
        yield return new WaitForSeconds(button2Time);
        Instantiate(button2);
    }
    private IEnumerator SpawnButton3()
    {
        yield return new WaitForSeconds(button3Time);
        Instantiate(button3);
    }
    private void ClearCheck()
    {
        if (button1Clicked && button2Clicked && button3Clicked)
            gameClear = true;
    }
    public Canvas GetCanvas()
    {
        return canvas;
    }
    public bool GetTimeOver()
    {
        return timeOver;
    }
    public void SetTimeOver(bool a)
    {
        timeOver = a;
    }
    public bool GetButton1Clicked()
    {
        return button1Clicked;
    }
    public void SetButton1Clicked(bool a)
    {
        button1Clicked = a;
    }
    public bool GetButton2Clicked()
    {
        return button2Clicked;
    }
    public void SetButton2Clicked(bool a)
    {
        button2Clicked = a;
    }
    public bool GetButton3Clicked()
    {
        return button3Clicked;
    }
    public void SetButton3Clicked(bool a)
    {
        button3Clicked = a;
    }
    public float GetButton1ClickTime()
    {
        return button1ClickTime;
    }
    public float GetButton2ClickTime()
    {
        return button2ClickTime;
    }
    public float GetButton3ClickTime()
    {
        return button3ClickTime;
    }
}
