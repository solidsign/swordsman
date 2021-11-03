using Game.Extra;
using Game.Inputs;
using Game.States.AI.Substates.Core;

namespace Game.States.AI.Substates
{
    public class Defence : AISubstate
    {
        private AIDuelLooker _looker;
        private AIInput _input;

        public Defence(AIInput input, AIDuelLooker looker)
        {
            _input = input;
            _looker = looker;
        }

        public override void Execute()
        {
            if (!(_looker.PlayerCanAttack() && _looker.PlayerIsAttacking())) return;
            Block(_looker.GetPlayersAttackDirection());
        }

        private void Block(Direction direction)
        {
            switch (direction)
            {
                case Direction.Bottom: 
                    _input.TriggerBlockBottom();
                    break;
                case Direction.Middle:
                    _input.TriggerBlockMiddle();
                    break;
                case Direction.Up:
                    _input.TriggerBlockUp();
                    break;
            }
        }

        public override bool IsFinished => !_looker.PlayerCanAttack();

        public override string ToString()
        {
            return nameof(Defence);
        }
    }
}