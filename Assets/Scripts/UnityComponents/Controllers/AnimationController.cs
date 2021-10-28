using System.Collections.Generic;
using UnityEngine;
using Game.Animations;

namespace Game
{
    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;
        private Dictionary<AnimationName, List<string>> _triggers;

        [SerializeField] private List<AnimationTriggerNames> triggerNames;
        
        private void Start()
        {
            InitializeDictionary();
            _animator = GetComponent<Animator>();
        }

        private void InitializeDictionary()
        {
            _triggers = new Dictionary<AnimationName, List<string>>(triggerNames.Count);
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

        public void SetAnimation(AnimationName animationName)
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