using System.Collections;
using Game.Extra;

namespace Game.States.Player
{
    public abstract class Attacked : BaseState
    {
        private AnimationSetter _animator;
        protected abstract PlayerAnimation _animation { get; }
        protected Attacked(StateHandler stateHandler)
        {
            _animator = stateHandler.GetComponent<AnimationSetter>();
        }
        public override void Enter()
        {
            _animator.SetAnimation(_animation);
        }

        public override bool VerifyNextState(string state) => false;
    }
}