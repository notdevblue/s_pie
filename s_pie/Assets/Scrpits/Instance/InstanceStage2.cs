﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceStage2 : MonoBehaviour
{
    #region 프리팹
    [SerializeField] private GameObject tile = null;
    [SerializeField] private GameObject wall = null;
    #endregion

    #region 프리팹 안 넣었을 때 (에디터에서만 돌아가는 코드)
#if UNITY_EDITOR
    private void Awake()
    {
        if (IsPrefabNull())
        {
            UnityEditor.EditorUtility.DisplayDialog("프리팹 오류", "프리팹을 찾을 수 없습니다.", "확인");
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
#endif
    #endregion

    private void Start()
    {
        Instantiate(tile);
    }

    #region 프리팹 널체크
#if UNITY_EDITOR
    private bool IsPrefabNull()
    {
        if (tile == null)
        {
            return true;
        }
        if(wall == null)
        {
            return true;
        }
        return false;
    }
#endif
    #endregion
}