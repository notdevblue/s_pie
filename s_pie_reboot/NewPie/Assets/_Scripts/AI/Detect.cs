using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Events;

namespace AI
{
   [RequireComponent(typeof(CircleCollider2D), typeof(EventCaller))]
   public class Detect : MonoBehaviour
   {
      // 이벤트
      private EventCaller _eventCaller;

      private CircleCollider2D _collider;

      private void Awake()
      {
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