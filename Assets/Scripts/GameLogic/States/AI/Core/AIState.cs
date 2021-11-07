using Game.Extra;
using Game.Inputs;

namespace Game.States.AI.Core
{
    public abstract class AIState : BaseState
    {
        protected SubstatesChain _substates;
        public override void Execute()
        {
            if (_substates.IsFinished) _substates.Reset();
            _substates.ExecuteCurrent();
        }

        public override void Exit()
        {
            _substates.Reset();
        }

        public override void Enter()
        {
            _substates.Reset();
            _substates.Start();
        }
    }
}