namespace Game.States
{
    public abstract class BaseState
    {
        public virtual void Enter() { }
        public virtual void Execute() { }
        public virtual void Exit() { }
        public abstract override string ToString();
        public virtual bool VerifyNextState(string state) => true;
    }
}