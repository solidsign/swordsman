using Game.Extra;
using Game.Inputs;
using Game.States.AI.Core;
using Game.States.AI.Substates;

namespace Game.States.AI
{
    public class Defencing : AIState
    {
        public override void Init(AIInput input, AIDuelLooker looker)
        {
            _substates = new SubstatesChain()
                .Add(new MoveFromPlayerDefencing(input, looker))
                .Add(new Defence(input, looker));
        }

        public override string ToString()
        {
            return nameof(Defencing);
        }
    }
}