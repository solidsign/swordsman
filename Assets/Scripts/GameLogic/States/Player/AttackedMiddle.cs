using Game.Extra;

namespace Game.States.Player
{
    public class AttackedMiddle : Attacked
    {
        public AttackedMiddle(StateHandler stateHandler) : base(stateHandler)
        {
        }

        public override string ToString()
        {
            return nameof(AttackedMiddle);
        }
        protected override PlayerAnimation _animation => PlayerAnimation.AttackedMiddle;
    }
}