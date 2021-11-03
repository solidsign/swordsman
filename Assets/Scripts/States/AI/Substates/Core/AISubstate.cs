namespace Game.States.AI.Substates.Core
{
    public abstract class AISubstate : BaseState
    {
        public abstract bool IsFinished { get; }
    }
}