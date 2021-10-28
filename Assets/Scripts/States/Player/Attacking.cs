using UnityEngine;

namespace Game.States.Player
{
    public abstract class Attacking : BaseState // TODO: create inheritors
    {
        protected Animator _animator;
        protected StateHandler _rival;
        public override void Init(StateHandler stateHandler)
        {
            _animator = stateHandler.GetComponent<Animator>();
            _rival = stateHandler.GetComponent<Rival>().RivalGameObject.GetComponent<StateHandler>();
        }
    }
}