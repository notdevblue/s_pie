using UnityEngine;
using System.Collections.Generic;
using System;

namespace Core.Events
{
   public class EventCaller : MonoBehaviour
   {
      [Header("이벤트")]
      public List<EventObject> callbacks
         = new List<EventObject>();

      /// <summary>
      /// 이벤트 호출
      /// </summary>
      /// <param name="comparable">찾을 이벤트</param>
      /// <param name="param">이벤트에 넘길 매개변수</param>
      public void Call(Predicate<EventObject> comparable, object param)
      {
         var events = callbacks.FindAll(comparable);
         events?.ForEach(e => e.callback?.Invoke(param));
      }

      /// <summary>
      /// 이벤트 추가 
      /// </summary>
      /// <param name="newEvent">넣을 이벤트 객체</param>
      public void AddEvent(EventObject newEvent)
      {
         callbacks.Add(newEvent);
      }
   }
}