using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("따라갈 무언가의 트렌스폼")]
    public Transform followTransform = null;

    [Header("카메라 부드럽게 움직일 정도 (작을수록 부드러움)")]
    [SerializeField] private float followSpeed = 0.05f;

    private Vector3 target = Vector3.zero;

    
    void Update()
    {
        FollowObject();
    }


    private void FollowObject()
    {
        target      = followTransform.position;
        target.z    = -10;

        transform.position = Vector3.Lerp(transform.position, target, followSpeed);
    }
}
