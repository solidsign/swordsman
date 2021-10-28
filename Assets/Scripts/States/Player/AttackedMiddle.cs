using Game.Animations;

namespace Game.States.Player
{
    public class AttackedMiddle : Attacked
    {
        public override string ToString()
        {
            return nameof(AttackedMiddle);
        }
        protected override PlayerAnimation _animation => PlayerAnimation.AttackedMiddle;
    }
}