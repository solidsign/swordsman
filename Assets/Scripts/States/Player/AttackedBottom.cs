using Game.Animations;

namespace Game.States.Player
{
    public class AttackedBottom : Attacked
    {
        public override string ToString()
        {
            return nameof(AttackedBottom);
        }

        protected override PlayerAnimation _animation => PlayerAnimation.AttackedBottom;
    }
}