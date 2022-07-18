using System;
using UnityEngine.Events;

namespace AI.Behaviour
{
   public class Decision
   {
      // 행동 우선순위
      public int Priority { get; private set; }
      // 키
      public string Key { get; private set; }

      /// <summary>
      /// 조건 만족 시
      /// </summary>
      public UnityEvent OnSatisfied;

      /// <summary>
      /// 상태 종료 시
      /// </summary>
      public UnityEvent OnExiting;

      // 조건들
      private Func<bool> _requirement;
      
      /// <summary>
      /// 행동 클레스 생성자
      /// </summary>
      /// <param name="priority">우선순위</param>
      /// <param name="key">키</param>
      /// <param name="requirement">이 행동을 위해 필요한 조건 (매 프레임 마다 실행)</param>
      /// <param name="OnExiting">상태 종료시 호출됨</param>
      /// <param name="OnSatisified">조건 만족시 호출됨</param>
      public Decision(int priority,
                      string key,
                      Func<bool> requirement,
                      UnityAction OnExiting,
                      UnityAction OnSatisified)
      {
         this.OnSatisfied  = new UnityEvent();
         this.OnExiting    = new UnityEvent();
         this.Priority     = priority;
         this.Key          = key;
         this._requirement = requirement;

         this.OnSatisfied.AddListener(OnSatisified);
         this.OnExiting.AddListener(OnExiting);
      }

      /// <summary>
      /// 이 행동을 실행하기 위한 조건을 추가합니다.
      /// </summary>
      public void AddRequirements(Func<bool> value)
         => _requirement += value;

      /// <summary>
      /// 이 행동을 실행할지 검사합니다.
      /// </summary>
      /// <returns>true when Satisfied</returns>
      public bool Check()
      {
         foreach(var act in _requirement.GetInvocationList())
         {
            if (!((Func<bool>)act)())
               return false;
         }
         return true;
      }

   }
}