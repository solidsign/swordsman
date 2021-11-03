using System.Collections.Generic;
using Game.Inputs;
using Game.States;
using Game.States.Player;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Weapon), typeof(BodyPosition), typeof(Speed))]
    public class SwordsmanStateHandler : StateHandler
    {
        private ISwordsmanInput _inputChecker;
        public Weapon Weapon { get; private set; }
        public BodyPosition BodyPosition { get; private set; }
        public Speed Speed { get; private set; }

        private bool _isMoving;

        private void Awake()
        {
            Weapon = GetComponent<Weapon>();
            BodyPosition = GetComponent<BodyPosition>();
            Speed = GetComponent<Speed>();
        }

        public void Init(ISwordsmanInput input)
        {
            _inputChecker = input;
        }

        protected override void InitializeDictionary()
        {
            States = new Dictionary<string, BaseState>()
            {
                {nameof(Idle), new Idle()},
                {nameof(MovingLeft), new MovingLeft()},
                {nameof(MovingRight), new MovingRight()},
                {nameof(AttackedUp), new AttackedUp()},
                {nameof(AttackedMiddle), new AttackedMiddle()},
                {nameof(AttackedBottom), new AttackedBottom()},
                {nameof(AttackingUp), new AttackingUp()},
                {nameof(AttackingMiddle), new AttackingMiddle()},
                {nameof(AttackingBottom), new AttackingBottom()},
                {nameof(BlockingUp), new BlockingUp()},
                {nameof(BlockingMiddle), new BlockingMiddle()},
                {nameof(BlockingBottom), new BlockingBottom()},
            };
        }

        protected override void SetStartState()
        {
            SetState(nameof(Idle));
            _isMoving = false;
        }

        protected override void CheckIfStateTransitionNeeded()
        {
            if (_inputChecker.AttackUp())
            {
                SetState(nameof(AttackingUp));
                return;
            }
            
            if (_inputChecker.AttackBottom())
            {
                SetState(nameof(AttackingBottom));
                return;
            }
            
            if (_inputChecker.AttackMiddle())
            {
                SetState(nameof(AttackingMiddle));
                return;
            }
            
            if (_inputChecker.BlockUp())
            {
                SetState(nameof(BlockingUp));
                return;
            }
            
            if (_inputChecker.BlockBottom())
            {
                SetState(nameof(BlockingBottom));
                return;
            }
            
            if (_inputChecker.BlockMiddle())
            {
                SetState(nameof(BlockingMiddle));
                return;
            }
            
            if (_isMoving)
            {
                if (_inputChecker.StopMove())
                {
                    SetState(nameof(Idle));
                    _isMoving = false;
                }
            }
            else
            {
                if (_inputChecker.StartMoveLeft())
                {
                    SetState(nameof(MovingLeft));
                    _isMoving = true;
                    return;
                }

                if (_inputChecker.StartMoveRight())
                {
                    SetState(nameof(MovingRight));
                    _isMoving = true;
                    return;
                }
            }
        }

        public string GetCurrentState() => CurrentState.ToString();
    }
}