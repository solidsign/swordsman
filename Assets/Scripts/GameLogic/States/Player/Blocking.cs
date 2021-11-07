using System.Collections;
using Game.Extra;
using UnityEngine;

namespace Game.States.Player
{
    /*
     * I understand it's not the smartest solution to create a bunch of inheritors
     * when I could just make _animation a property and initialize it through constructor
     * but I didn't want this state and Attacking to have another SetState than other states have.
     * And I didn't want to allocate new class every time when SetState is called,
     * so it's was the best what I came up with.
     * Actually I just forgot about existence of constructors, so it's really stupid
     * I just tunnel visioned on Init method
     * Maybe I will refactor this later
     */
    public abstract class Blocking : BaseState
    {
        private string _blockedAttack;
        private AnimationSetter _animator;
        private StateHandler _stateHandler;
        protected abstract PlayerAnimation _animation { get; }
        protected Blocking(StateHandler stateHandler)
        {
            _blockedAttack = nameof(Attacked) + this.ToString().Remove(0, nameof(Blocking).Length);
            _animator = stateHandler.GetComponent<AnimationSetter>();
            _stateHandler = stateHandler;
        }

        public override void Enter()
        {
            _stateHandler.StopAllCoroutines();
            _animator.SetAnimation(_animation);
            _stateHandler.StartCoroutine(WaitForNextState());
        }

        public override void Exit()
        {
            _stateHandler.StopAllCoroutines();
        }


        public override bool VerifyNextState(string state)
        {
            return state != _blockedAttack;
        }
        
        private IEnumerator WaitForNextState()
        {
            yield return new WaitForSeconds(PlayerAnimationConfiguration.BlockStateTime);
            _stateHandler.SetState(nameof(Idle));
        }
    }
}