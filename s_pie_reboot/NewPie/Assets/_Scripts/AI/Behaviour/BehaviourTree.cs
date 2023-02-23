using System;
using System.Collections.Generic;
using Core.Events;
using UnityEngine;

namespace AI.Behaviour
{
    public class BehaviourTree : MonoBehaviour
    {
        public bool Enabled { get; set; } = true;

        private List<Decision> _decisions = new List<Decision>();

        private Decision _currentDecision = null;
        private Decision CurrentDecision
        {
            get => _currentDecision;
            set
            {
                _currentDecision.OnExiting?.Invoke();
                _currentDecision = value;
            }
        }

        private void Awake()
        {
            if (_decisions.Count <= 0)
            {
                Logger.Log($"{gameObject.name}::BehaviourTree > "
                         + "Decision 이 없습니다. 비활성화 상태로 전환합니다.");
                Enabled = false;
            }
        }

        private void Update()
        {
            if (!Enabled) return;

#if UNITY_EDITOR
            bool failsafe = true; // decision 잘못 넣었을 때를 위해
#endif
            _decisions.ForEach(decision =>
            {
                if (!decision.Check())
                    return;


                if (decision.Check())
                {
#if UNITY_EDITOR
                    failsafe = false;
#endif
                    if (CurrentDecision == null ||
                       CurrentDecision.Priority < decision.Priority)
                        CurrentDecision = decision;
                }
            });

#if UNITY_EDITOR
            if (failsafe)
            {
                Logger.Log($"{gameObject.name}::BehaviourTree > "
                          + "아무 Decision 도 선택되지 않음", LogLevel.Fatal);
                throw new Exception();
            }
#endif
            CurrentDecision.OnSatisfied.Invoke();
        }

        public void AddDecision(Decision decision)
        {
            string errmsg = "";

            if (_decisions.Find(x => decision.Priority == x.Priority) != null)
                errmsg += " Priority 중복";

            if (_decisions.Find(x => decision.Key == x.Key) != null)
                errmsg += " Key 중복";

            if (errmsg.CompareTo("") != 0)
            {
                Logger.Log($"{gameObject.name}::BehaviourTree > "
                         + $"Decision 추가 중 에러:{errmsg}", LogLevel.Error);
                return;
            }

            _decisions.Add(decision);
        }


    }
}