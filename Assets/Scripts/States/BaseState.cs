namespace Game.States
{
    public abstract class BaseState
    {
        public virtual void Init(StateHandler stateHandler) { }
        public virtual void Enter() { }
        public virtual void Execute() { }
        public virtual void Exit() { }
        public abstract override string ToString();
    }
}