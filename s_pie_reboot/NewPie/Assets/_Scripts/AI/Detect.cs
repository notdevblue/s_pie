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
      public float radius = 1.0f;

      private CircleCollider2D _collider;
      private EventCaller _eventCaller;

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