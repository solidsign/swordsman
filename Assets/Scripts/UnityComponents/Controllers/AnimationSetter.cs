using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Extra;
using Random = UnityEngine.Random;

namespace Game
{
    public class AnimationSetter : MonoBehaviour
    {
        private Animator _animator;
        private Dictionary<PlayerAnimation, List<string>> _triggers;

        [SerializeField] private List<AnimationTriggerNames> triggerNames;

        private void Awake()
        {
            InitializeDictionary();
            _animator = GetComponent<Animator>();
        }

        private void InitializeDictionary()
        {
            _triggers = new Dictionary<PlayerAnimation, List<string>>(triggerNames.Count);
            foreach (var triggerName in triggerNames)
            {
                if (_triggers.ContainsKey(triggerName.AnimationName))
                {
                    _triggers[triggerName.AnimationName].AddRange(triggerName.TriggerNames);
                }
                else
                {
                    _triggers.Add(triggerName.AnimationName, triggerName.TriggerNames);
                }
            }
        }

        public void SetAnimation(PlayerAnimation animationName)
        {
            if (!_triggers.ContainsKey(animationName))
            {
#if UNITY_EDITOR
                Debug.Log(name + " was called to enter Animation:" + animationName.ToString() + " but doesn't have it");
#endif
                return;
            }
            var animationVariants = _triggers[animationName];
            int i = Random.Range(0, animationVariants.Count - 1);
            _animator.SetTrigger(animationVariants[i]);
        }
        
    }
}