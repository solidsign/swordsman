using System.Collections;
using System.Threading.Tasks;
using Game.Extra;
using UnityEngine;

namespace Game.States.Player
{
    public abstract class Attacking : BaseState
    {
        private AnimationSetter _animator;
        private Weapon _weapon;
        private AttackHandler _attackHandler;
        private SwordsmanStateHandler _stateHandler;
        private bool _preparing;
        private Task _waitingForNextState = null;
        protected abstract Direction _direction { get; }
        protected abstract PlayerAnimation _attackAnimation { get; }
        protected abstract PlayerAnimation _prepareAnimation { get; }
        protected Attacking(SwordsmanStateHandler stateHandler)
        {
            _animator = stateHandler.GetComponent<AnimationSetter>();
            _weapon = stateHandler.GetComponent<Weapon>();
            _stateHandler = stateHandler;
            _attackHandler = stateHandler.GetComponent<AttackHandlerInstance>().AttackHandler;
        }

        public override void Enter()
        {
            _stateHandler.StopAllCoroutines();
            _stateHandler.StartCoroutine(PrepareForAttack());
            _waitingForNextState = null;
        }

        public override void Exit()
        {
            _stateHandler.StopAllCoroutines();
            _waitingForNextState?.Dispose();
        }

        private IEnumerator PrepareForAttack()
        {
            _preparing = true;
            _animator.SetAnimation(_prepareAnimation);
            yield return new WaitForSeconds(_weapon.PrepareForAttackTime);
            _preparing = false;
            Attack();
        }


        private void Attack()
        {
            _animator.SetAnimation(_attackAnimation);
            _attackHandler.Attack(_stateHandler, _direction, _weapon.AttackDistance);
            _waitingForNextState = WaitForNextState();
        }

        private async Task WaitForNextState()
        {
            await Task.Delay((int) (PlayerAnimationConfiguration.AttackStateTime * 1000));
            _stateHandler.SetState(nameof(Idle));
        }

        public override bool VerifyNextState(string state)
        {
            if (_preparing)
            {
                return state.Contains(nameof(Blocking)) || state.Contains(nameof(Attacked)) || state.Contains(nameof(Attacking));
            }
            return true;
        }
    }
}