using UnityEngine;

namespace Game.States.Player
{
    public class Dead : BaseState
    {
        private Animator _animator;
        private static readonly int DeathAnimation = Animator.StringToHash(nameof(Dead));
        public override void Init(StateHandler stateHandler)
        {
            _animator = stateHandler.GetComponent<Animator>();
        }

        public override void Enter()
        {
            _animator.SetTrigger(DeathAnimation);
        }

        public override string ToString()
        {
            return nameof(Dead);
        }
    }
}