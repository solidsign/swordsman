using Game.Extra;
using Game.Inputs;

namespace Game
{
    public abstract class AIStateHandler : StateHandler
    {
        public abstract void Init(AIInput input, DuelLooker duelLooker);
    }
}