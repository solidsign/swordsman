using Game.Extra;

namespace Game.States.Player
{
    public class AttackedBottom : Attacked
    {
        public AttackedBottom(StateHandler stateHandler) : base(stateHandler)
        {
        }

        public override string ToString()
        {
            return nameof(AttackedBottom);
        }

        protected override PlayerAnimation _animation => PlayerAnimation.AttackedBottom;
    }
}