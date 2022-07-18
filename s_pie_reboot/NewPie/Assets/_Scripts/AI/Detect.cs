using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Events;
using UnityEditor;

namespace AI
{
   [RequireComponent(typeof(CircleCollider2D), typeof(EventCaller))]
   public class Detect : MonoBehaviour
   {      
      // 감지 거리
      [HideInInspector]
      public float radius = 1.0f;

      // 이벤트
      private EventCaller _eventCaller;

      private CircleCollider2D _collider;

      private void Awake()
      {
         _collider    = GetComponent<CircleCollider2D>();
         _eventCaller = GetComponent<EventCaller>();
      }

      private void OnTriggerEnter2D(Collider2D other)
      {
         _eventCaller.Call(x => {
            return (other.tag.CompareTo(x.key) == 0)
                || (x.key.Trim() == "");
         }, other.gameObject);
      }
   }
}