using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    
    [Header("효과 시간")]
    public float shakeTime = 0.3f;

    [SerializeField] private Transform shakeTarget = null;

    // 데미지 그대로 넣으면 미친듯이 흔들리기 때문에
    private readonly    float               shakeAmount = 0.005f;
    private             WaitForEndOfFrame   waitFrame   = null;

    private void Awake()
    {
        waitFrame = new WaitForEndOfFrame();
        if(shakeTarget == null) { Debug.LogError("# 오브젝트 안 붙임 #"); }
    }

    private void OnEnable() // TODO : 켜질때 변수를 넘겨 주고 싶은데 흠흠
    {
        StartCoroutine(CamShake(20.0f));
    }


    public IEnumerator CamShake(float amount)
    {
        float startTime = Time.time;

        while(startTime + shakeTime > Time.time)
        {
            shakeTarget.transform.localPosition= new Vector3(Random.Range(-amount * shakeAmount, amount * shakeAmount),
                                                            Random.Range(-amount * shakeAmount, amount * shakeAmount), 0.0f);

            yield return waitFrame;
        }

        shakeTarget.transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);
    }
}
