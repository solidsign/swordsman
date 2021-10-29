using Game.Extra;

namespace Game.States.Player
{
    public class BlockingMiddle : Blocking
    {
        public override string ToString()
        {
            return nameof(BlockingMiddle);
        }

        protected override PlayerAnimation _animation => PlayerAnimation.BlockingMiddle;
    }
}