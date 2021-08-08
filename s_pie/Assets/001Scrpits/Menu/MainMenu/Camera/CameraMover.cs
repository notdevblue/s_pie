using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일단 메인 카메라 한정

public class CameraMover : MonoBehaviour
{
    static private CameraMover inst = null;                   // static 함수 접근 용

    private WaitForEndOfFrame wait = new WaitForEndOfFrame(); // 계속 인스턴스를 만들고싶지 않았음
    private Transform         cam  = null;                    // 간결한 코드를 위해

    public delegate void Callback();                          // 콜백용



    private void Awake()
    {
        inst = this;
        cam = Camera.main.transform;
    }


    /// <summary>
    /// 카메라의 위치를 설정합니다.
    /// </summary>
    /// <param name="pos">설정할 위치</param>
    static public void SetCameraPos(Vector2 pos)
    {
        inst.cam.position = new Vector3(pos.x, pos.y, inst.cam.position.z);
    }


    /// <summary>
    /// 카메라를 이동시킵니다.
    /// </summary>
    /// <param name="pos">이동시킬 위치</param>
    static public void MoveCamera(Vector2 pos, float duration, Callback callback = null)
    {
        inst.StartCoroutine(inst.CamMovement(pos, duration, callback));
    }

    private IEnumerator CamMovement(Vector2 pos, float duration, Callback callback)
    {
        Vector2 origin = cam.position;
        Vector2 vect   = pos - (Vector2)cam.position; // lerp 용도
        Vector3 lerp;                                 // 카메라의 z 값 때문에

        // Sin함수 용도
        float degree = 0;
        float add    = Mathf.PI / 2.0f / duration; 


        while (degree <= Mathf.PI / 2.0f)
        {
            degree += add * Time.deltaTime;

            lerp = origin + vect * Mathf.Sin(degree);
            lerp.z = -10; 
            cam.position = lerp;

            yield return wait;
        }
        
        callback?.Invoke();
    }
}
