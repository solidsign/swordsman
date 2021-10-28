using Game.Animations;
using UnityEngine;

namespace Game.States.Player
{
    public class Dead : BaseState
    {
        private AnimationSetter _animator;
        public override void Init(StateHandler stateHandler)
        {
            _animator = stateHandler.GetComponent<AnimationSetter>();
        }

        public override void Enter()
        {
            _animator.SetAnimation(PlayerAnimation.Death);
        }

        public override string ToString()
        {
            return nameof(Dead);
        }
    }
}