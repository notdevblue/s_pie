using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScirpt : MonoBehaviour
{
    private Vector2 currentPosition = Vector2.zero;
    private Vector2 targetPosition = Vector2.zero;

    void Start()
    {
        
    }

    void Update()
    {
        MoveObject();
    }
    private void MoveObject()
    {
        currentPosition = transform.localPosition;
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        currentPosition = targetPosition;
        transform.localPosition = currentPosition;
    }
    public Vector2 GetCurrentPosition()
    {
        return currentPosition;
    }
}
