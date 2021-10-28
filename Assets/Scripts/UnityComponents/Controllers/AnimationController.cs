using System.Collections.Generic;
using UnityEngine;
using Game.Core;

namespace Game
{
    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;
        private Dictionary<AnimationName, string[]> _triggers;

        [SerializeField] private List<string[]> _triggerNames;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetAnimation(AnimationName animationName)
        {
            var animationVariants = _triggers[animationName];
            int i = Random.Range(0, animationVariants.Length - 1);
            _animator.SetTrigger(animationVariants[i]);
        }
        
    }
}