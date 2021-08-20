using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiancaMove : MonoBehaviour
{
    // 따로 클래스를 파야 함
    [SerializeField] private float moveSpeed    = 3.0f;
    [Header("걷기 이동속도 (moveSpeed * walkBoost)")]
    [SerializeField] private float walkBoost    = 0.8f;

    [Header("대쉬 힘 (keyInputVector * dashBoost)")]
    [SerializeField] private float dashBoost    = 1.5f;

    [Header("대쉬 쿨타임")]
    [SerializeField] private float dashCooldown = 2.0f;


    [Header("키 매핑")] // 따로 클래스를 파야 함
    public KeyCode up       = KeyCode.UpArrow;
    public KeyCode down     = KeyCode.DownArrow;
    public KeyCode left     = KeyCode.LeftArrow;
    public KeyCode right    = KeyCode.RightArrow;
    public KeyCode sprint   = KeyCode.LeftShift;
    public KeyCode walk     = KeyCode.LeftAlt;


    private float           dashPressedTime     = 0.0f;         // 키 누른 시간 저장용
    private Vector3         keyInputVector      = Vector3.zero;
    private Rigidbody2D     rigidBody           = null;
    private BiancaStatus    pStat               = null;




    private void Awake()
    {
        rigidBody   = GetComponent<Rigidbody2D>();
        pStat       = GetComponent<BiancaStatus>(); if(pStat == null) { Debug.LogError("Cannot find BiancaStatus.cs"); }
    }

    void Update()
    {
        Run();
        Dash();
    }

    // 부모 클래스에서 상속받아야 함, 또는 인터페이스
    private void Dash()
    {
        if (Input.GetKeyDown(sprint) && dashPressedTime + dashCooldown < Time.time && !pStat.isDashing) // TODO : 피격시 뒤로 밀려나는 효과 있을때는 대쉬 못하게 해야함 // TODO : 오 가독성 이런
        {
            pStat.isDashing = true; // TODO : 재대로 들어가지 않음
            dashPressedTime = Time.time;
            rigidBody.AddRelativeForce(keyInputVector.normalized * dashBoost, ForceMode2D.Impulse);
        }

        if(rigidBody.velocity.x < 0.01f && rigidBody.velocity.y < 0.01f)
        {
            pStat.isDashing = false;
        }
    }

    // 부모 클래스에서 상속받아야 함, 또는 인터페이스
    private void Run()
    {
        keyInputVector = Vector3.zero;

        if (Input.GetKey(up))                           { keyInputVector.y =  1; }
        if (Input.GetKey(down))                         { keyInputVector.y = -1; }
        if (Input.GetKey(down) && Input.GetKey(up))     { keyInputVector.y =  0; } // ws 동시입력

        if (Input.GetKey(left))                         { keyInputVector.x = -1; }
        if (Input.GetKey(right))                        { keyInputVector.x =  1; }
        if (Input.GetKey(right) && Input.GetKey(left))  { keyInputVector.x =  0; } // ad 동시입력

        if (Input.GetKeyDown(walk))                     { moveSpeed *= walkBoost; pStat.isWalking = true;  }
        if (Input.GetKeyUp(walk))                       { moveSpeed /= walkBoost; pStat.isWalking = false; } // 걷기

        transform.Translate(keyInputVector.normalized * moveSpeed * Time.deltaTime);
    }

}
