using Game.Extra;

namespace Game.States.Player
{
    public class AttackedUp : Attacked
    {
        public override string ToString()
        {
            return nameof(AttackedUp);
        }
        protected override PlayerAnimation _animation => PlayerAnimation.AttackedUp;
    }
}