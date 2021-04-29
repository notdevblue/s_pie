using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    
    [Header("효과 시간")]
    public float shakeTime = 0.3f;

    // 데미지 그대로 넣으면 미친듯이 흔들리기 때문에
    private readonly    float               shakeAmount = 0.005f;
    private             WaitForEndOfFrame   waitFrame   = null;

    private void Awake()
    {
        waitFrame = new WaitForEndOfFrame();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)) // 따로 함수를 부르도록 만들 것 (그저 테스트를 해보고 싶었습니다...)
        {
            StartCoroutine(CamShake(20.0f));
        }
    }


    public IEnumerator CamShake(float amount)
    {
        float startTime = Time.time;

        while(startTime + shakeTime > Time.time)
        {
            transform.localPosition= new Vector3(Random.Range(-amount * shakeAmount, amount * shakeAmount),
                                                 Random.Range(-amount * shakeAmount, amount * shakeAmount), 0.0f);

            yield return waitFrame;
        }

        transform.localPosition = Vector3.zero;
    }
}
