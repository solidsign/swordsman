using Game.Extra;
using Game.Inputs;
using Game.States.AI.Substates.Core;

namespace Game.States.AI.Substates
{
    public class MoveFromPlayerDefencing : AISubstate
    {
        private AIInput _input;
        private AIDuelLooker _looker;

        public MoveFromPlayerDefencing(AIInput input, AIDuelLooker looker)
        {
            _input = input;
            _looker = looker;
        }
        
        public override void Enter()
        {
            if (!_looker.PlayerIsToTheLeft())
            {
                _input.TriggerStartMoveLeft();
            }
            else
            {
                _input.TriggerStartMoveRight();
            }
        }

        public override void Exit()
        {
            _input.TriggerStopMove();
        }

        public override bool IsFinished => _looker.PlayerCanAttack() && _looker.PlayerIsAttacking();

        public override string ToString()
        {
            return nameof(MoveFromPlayerDefencing);
        }
    }
}