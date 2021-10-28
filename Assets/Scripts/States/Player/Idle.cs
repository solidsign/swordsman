using Game.Extra;
using UnityEngine;

namespace Game.States.Player
{
    public class Idle : BaseState
    {
        private AnimationSetter _animator;

        public override void Init(StateHandler stateHandler)
        {
            _animator = stateHandler.GetComponent<AnimationSetter>();
        }

        public override void Enter()
        {
            _animator.SetAnimation(PlayerAnimation.Idle);
        }

        public override string ToString()
        {
            return nameof(Idle);
        }
    }
}