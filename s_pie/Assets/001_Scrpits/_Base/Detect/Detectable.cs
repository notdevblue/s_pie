using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Detectable
{
    [SerializeField]
    DetectType type { get; set; }
}


/*
만약 있다면 => GetType => 상황에 맞는 Detected delegate ?
r*/