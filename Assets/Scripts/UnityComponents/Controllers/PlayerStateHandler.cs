using System;
using System.Collections.Generic;
using Game.Inputs;
using Game.States;
using Game.States.Player;

namespace Game
{
    public class PlayerStateHandler : StateHandler
    {
        private InputChecker _inputChecker;

        private void Awake()
        {
            _inputChecker = InputChecker.GetInstance();
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
            SetState(nameof(Idle));
        }

        protected override void CheckIfStateTransitionNeeded()
        {
            if (_inputChecker.MoveLeft())
            {
                SetState(nameof(MovingLeft));
                return;
            }

            if (_inputChecker.MoveRight())
            {
                SetState(nameof(MovingRight));
                return;
            }

            if (_inputChecker.AttackUp())
            {
                SetState(nameof(AttackingUp));
                return;
            }
            
            if (_inputChecker.AttackBottom())
            {
                SetState(nameof(AttackedBottom));
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
        }
    }
}