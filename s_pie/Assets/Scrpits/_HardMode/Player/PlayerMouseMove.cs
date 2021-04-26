using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseMove : MonoBehaviour
{
    private Vector3 mousePos = Vector3.zero;
    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0.0f;
        }
        transform.position = mousePos; // 귀찬아서 일케했지만 시간단위로 움직여야함
    }
}
