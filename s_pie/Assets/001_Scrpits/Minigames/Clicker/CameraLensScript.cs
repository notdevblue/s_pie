using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLensScript : MonoBehaviour
{
    private Animator anim = null;
    private ClickerManager clickerManager = null;
    private GameManager gameManager = null;

    [SerializeField]
    private AudioSource audi = null;



    private int cameraHp = 10;
    private int firstCameraHp = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        clickerManager = FindObjectOfType<ClickerManager>();

        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();

        firstCameraHp = cameraHp;
    }

    // Update is called once per frame
    void Update()
    {
        AnimationPlay();
    }
    public void OnClick()
    {
        if (!clickerManager.GetGameIsClear() && !gameManager.GetGameOver())
        {
            cameraHp--;
            audi.Play();
        }
        if (cameraHp <= 0)
        {
            clickerManager.SetGameIsClear(true);
        }
    }
    void AnimationPlay()
    {
        if (cameraHp == firstCameraHp)
        {
            // 기본상태로 애니메이션 재생
            anim.Play("CameraLens_Clean");
        }
        if (cameraHp == clickerManager.GetBreak1())
        {
            // 살짝 금간상태로 애니메이션 재생
            anim.Play("CameraLens_Scratch1");
        }
        if (cameraHp == clickerManager.GetBreak2())
        {
            // 금 많이 간 상태로 애니메이션 재생
            anim.Play("CameraLens_Scratch2");
        }
        if (cameraHp == 0)
        {
            // 깨진 상태로 애니메이션 재생
            anim.Play("CameraLens_Broken");
        }
    }
}
