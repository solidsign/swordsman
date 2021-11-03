﻿using Game.Extra;
using Game.Inputs;
using Game.States.AI.Core;
using Game.States.AI.Substates;
using Game.States.AI.Substates.Core;

namespace Game.States.AI
{
    public class Attacking : AIState
    {
        public override void Init(AIInput aiInput, AIDuelLooker looker)
        {
            _substates = new SubstatesChain()
                .Add(new MoveToPlayerForAttack(aiInput, looker))
                .Add(new Attack(aiInput, looker));
        }

        public override string ToString()
        {
            return nameof(Attacking);
        }
    }
}