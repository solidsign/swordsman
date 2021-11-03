﻿using System.Collections;
using Game.Extra;
using UnityEngine;

namespace Game.States.Player
{
    public abstract class Attacking : BaseState
    {
        private AnimationSetter _animator;
        private Weapon _weapon;
        private DuelController _duelController;
        private SwordsmanStateHandler _stateHandler;
        private bool _preparing;
        protected abstract Direction _direction { get; }
        protected abstract PlayerAnimation _attackAnimation { get; }
        protected abstract PlayerAnimation _prepareAnimation { get; }
        public override void Init(StateHandler stateHandler)
        {
            _animator = stateHandler.GetComponent<AnimationSetter>();
            _weapon = stateHandler.GetComponent<Weapon>();
            _stateHandler = stateHandler as SwordsmanStateHandler;
            _duelController = stateHandler.GetComponent<DuelControllerInstance>().DuelController;
        }

        public override void Enter()
        {
            _stateHandler.StopAllCoroutines();
            _stateHandler.StartCoroutine(PrepareForAttack());
        }

        public override void Exit()
        {
            _stateHandler.StopAllCoroutines();
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
            _duelController.Attack(_stateHandler, _direction, _weapon.AttackDistance);
            _stateHandler.StartCoroutine(WaitForNextState());
        }

        private IEnumerator WaitForNextState()
        {
            yield return new WaitForSeconds(PlayerAnimationConfiguration.AttackStateTime);
            _stateHandler.SetState(nameof(Idle));
        }

        public override bool VerifyNextState(string state)
        {
            if (_preparing)
            {
                return state.Contains(nameof(Blocking)) || state.Contains(nameof(Attacked)) || state.Contains(nameof(Attacking));
            }
            else
            {
                return true;
            }
        }
    }
}