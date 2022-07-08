using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
   [RequireComponent(typeof(CircleCollider2D))]
   public class Detect : MonoBehaviour
   {
      [Header("감지 거리")]
      public float radius = 1.0f;

      [Header("감지할 테그들")]
      public List<string> detectTags
         = new List<string>();

      private CircleCollider2D _collider;

      private void Awake()
      {
         _collider = GetComponent<CircleCollider2D>();
      }

      void Update()
      {
      }
   }
}