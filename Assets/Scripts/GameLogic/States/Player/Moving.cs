using Game.Extra;
using UnityEngine;

namespace Game.States.Player
{
    public abstract class Moving : BaseState
    {
        protected AnimationSetter _animator;
        protected Rigidbody2D _rigidbody;
        protected float _speed;

        protected Moving(StateHandler stateHandler)
        {
            _animator = stateHandler.GetComponent<AnimationSetter>();
            _rigidbody = stateHandler.GetComponent<Rigidbody2D>();
            _speed = stateHandler.GetComponent<Speed>().Value;
        }

        public override void Enter()
        {
            _animator.SetAnimation(PlayerAnimation.Moving);
        }
    }
}