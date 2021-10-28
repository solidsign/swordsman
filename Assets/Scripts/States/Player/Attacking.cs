using UnityEngine;

namespace Game.States.Player
{
    public abstract class Attacking : BaseState // TODO: create inheritors
    {
        protected AnimationSetter _animator;
        protected Weapon _weapon;
        public override void Init(StateHandler stateHandler)
        {
            _animator = stateHandler.GetComponent<AnimationSetter>();
            _weapon = stateHandler.GetComponent<Weapon>();
        }
    }
}