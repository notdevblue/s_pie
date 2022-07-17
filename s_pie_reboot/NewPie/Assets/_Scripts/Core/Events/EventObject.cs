using UnityEngine.Events;
using System;

namespace Core.Events
{
   [Serializable]
   public class EventObject
   {
      // key
      public string key;

      // key 에 해당하는 callback
      public UnityEvent<object> callback;

      public EventObject(string key, UnityEvent<object> callback)
      {
         this.key = key;
         this.callback = callback;
      }
   }
}