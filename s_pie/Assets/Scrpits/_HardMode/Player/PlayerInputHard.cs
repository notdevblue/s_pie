using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHard : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3.0f;


    private Vector3 mousePos    = Vector3.zero;
    private bool    isCollision = false;


    [Header("키 매핑")]
    public KeyCode up = KeyCode.UpArrow;
    public KeyCode down = KeyCode.DownArrow;
    public KeyCode left = KeyCode.LeftArrow;
    public KeyCode right = KeyCode.RightArrow;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        mousePos = Vector3.zero;

        if (Input.GetKey(up)) { mousePos.y = 1; }
        if (Input.GetKey(down)) { mousePos.y = -1; }
        if (Input.GetKey(down) && Input.GetKey(up)) { mousePos.y = 0; } // ws 동시입력

        if (Input.GetKey(left)) { mousePos.x = -1; }
        if (Input.GetKey(right)) { mousePos.x = 1; }
        if (Input.GetKey(right) && Input.GetKey(left)) { mousePos.x = 0; } // ad 동시입력


        transform.position = Vector3.MoveTowards(transform.position, mousePos + transform.position, moveSpeed * Time.deltaTime);
    }

}
