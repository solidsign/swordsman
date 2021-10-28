using UnityEngine;

namespace Game.States.Player
{
    public abstract class Blocking : BaseState
    {
        protected AnimationSetter _animator;
        public override void Init(StateHandler stateHandler)
        {
            _animator = stateHandler.GetComponent<AnimationSetter>();
        }
    }
}