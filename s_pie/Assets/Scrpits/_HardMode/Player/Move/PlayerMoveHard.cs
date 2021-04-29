using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveHard : MonoBehaviour
{
    [SerializeField] private float moveSpeed    = 3.0f;
    [Header("달리기 이동속도 (moveSpeed * sprintBoost)")]
    [SerializeField] private float sprintBoost  = 1.2f;
    [Header("걷기 이동속도 (moveSpeed * walkBoost)")]
    [SerializeField] private float walkBoost    = 0.8f;

    [Header("키 매핑")]
    public KeyCode up       = KeyCode.UpArrow;
    public KeyCode down     = KeyCode.DownArrow;
    public KeyCode left     = KeyCode.LeftArrow;
    public KeyCode right    = KeyCode.RightArrow;
    public KeyCode sprint   = KeyCode.LeftShift;
    public KeyCode walk     = KeyCode.LeftAlt;


    private Vector3 keyInputVector = Vector3.zero;


    void Update()
    {
        Move();
    }

    private void Move()
    {
        keyInputVector = Vector3.zero;

        if (Input.GetKey(up))                           { keyInputVector.y =  1; }
        if (Input.GetKey(down))                         { keyInputVector.y = -1; }
        if (Input.GetKey(down) && Input.GetKey(up))     { keyInputVector.y =  0; } // ws 동시입력

        if (Input.GetKey(left))                         { keyInputVector.x = -1; }
        if (Input.GetKey(right))                        { keyInputVector.x =  1; }
        if (Input.GetKey(right) && Input.GetKey(left))  { keyInputVector.x =  0; } // ad 동시입력

        if (Input.GetKeyDown(sprint))                   { moveSpeed *= sprintBoost; }
        if (Input.GetKeyUp(sprint))                     { moveSpeed /= sprintBoost; } // 달리기

        if (Input.GetKeyDown(walk))                     { moveSpeed *= walkBoost; }
        if (Input.GetKeyUp(walk))                       { moveSpeed /= walkBoost; } // 걷기

        transform.position = Vector3.MoveTowards(transform.position, keyInputVector + transform.position, moveSpeed * Time.deltaTime);
    }

}
