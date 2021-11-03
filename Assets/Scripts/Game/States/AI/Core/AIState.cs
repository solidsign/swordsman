using Game.Extra;
using Game.Inputs;
using Game.States.AI.Substates.Core;

namespace Game.States.AI.Core
{
    public abstract class AIState
    {
        protected SubstatesChain _substates;
        public abstract void Init(AIInput input, AIDuelLooker looker);
        public virtual void Execute()
        {
            if (_substates.IsFinished) _substates.Reset();
            _substates.ExecuteCurrent();
        }

        public virtual void Exit()
        {
            _substates.Reset();
        }

        public virtual void Enter()
        {
            _substates.Reset();
        }
    }
}