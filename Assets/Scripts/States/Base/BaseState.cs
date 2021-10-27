namespace Game.States.Base
{
    public abstract class BaseState
    {
        public virtual void Init(StateHandler stateHandler) { }
        public virtual void Enter() { }
        public abstract bool IsFinished();
        public virtual void Execute() { }
        public virtual void Exit() { }
    }
}