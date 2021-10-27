using UnityEngine;

namespace Game.States.Player
{
    public abstract class Blocking : BaseState
    {
        protected Animator _animator;
        public override void Init(StateHandler stateHandler)
        {
            _animator = stateHandler.GetComponent<Animator>();
        }
    }
}