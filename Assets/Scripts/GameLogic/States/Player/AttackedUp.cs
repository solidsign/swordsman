using Game.Extra;

namespace Game.States.Player
{
    public class AttackedUp : Attacked
    {
        public AttackedUp(StateHandler stateHandler) : base(stateHandler)
        {
        }

        public override string ToString()
        {
            return nameof(AttackedUp);
        }
        protected override PlayerAnimation _animation => PlayerAnimation.AttackedUp;
    }
}