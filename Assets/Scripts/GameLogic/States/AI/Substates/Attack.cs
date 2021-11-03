using Game.Extra;
using Game.Inputs;
using Game.States.AI.Substates.Core;
using UnityEngine;

namespace Game.States.AI.Substates
{
    public class Attack : AISubstate
    {
        private AIDuelLooker _looker;
        private AIInput _input;

        public Attack(AIInput input, AIDuelLooker looker)
        {
            _input = input;
            _looker = looker;
        }

        public override void Execute()
        {
            if (_looker.AIIsAttacking()) return;
            AttackInRandomDirection();
        }

        private void AttackInRandomDirection()
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    _input.TriggerAttackBottom();
                    break;
                case 1:
                    _input.TriggerAttackMiddle();
                    break;
                case 2:
                    _input.TriggerAttackUp();
                    break;
            }
        }
        
        public override bool IsFinished => !_looker.AICanAttack();

        public override string ToString()
        {
            return nameof(Attack);
        }
    }
}