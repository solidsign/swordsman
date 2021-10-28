namespace Game.States.Player
{
    public abstract class Blocking : BaseState
    {
        private string _blockedAttack;
        protected AnimationSetter _animator;
        public override void Init(StateHandler stateHandler)
        {
            _blockedAttack = nameof(Attacked) + this.ToString().Remove(0, nameof(Blocking).Length);
            _animator = stateHandler.GetComponent<AnimationSetter>();
        }

        public override bool VerifyNextState(string state)
        {
            return state != _blockedAttack;
        }
    }
}