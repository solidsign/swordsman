using UnityEngine;

namespace Game.States.Player
{
    public class Idle : BaseState
    {
        private Animator _animator;
        private const string Name = "Idle";
        private static readonly int IdleAnimation = Animator.StringToHash(Name);

        public override void Init(StateHandler stateHandler)
        {
            _animator = stateHandler.GetComponent<Animator>();
        }

        public override void Enter()
        {
            _animator.SetTrigger(IdleAnimation);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}