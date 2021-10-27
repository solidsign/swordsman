using UnityEngine;

namespace Game.States.Player
{
    public abstract class Moving : BaseState
    {
        protected Animator _animator;
        protected Rigidbody2D _rigidbody;
        protected float _speed;
        private static readonly int MovingAnimation = Animator.StringToHash(nameof(Moving));

        public override void Init(StateHandler stateHandler)
        {
            _animator = stateHandler.GetComponent<Animator>();
            _rigidbody = stateHandler.GetComponent<Rigidbody2D>();
            _speed = stateHandler.GetComponent<Speed>().Value;
        }

        public override void Enter()
        {
            _animator.SetTrigger(MovingAnimation);
        }
    }
}