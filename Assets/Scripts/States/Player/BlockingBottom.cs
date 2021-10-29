using Game.Extra;

namespace Game.States.Player
{
    public class BlockingBottom : Blocking
    {
        public override string ToString()
        {
            return nameof(BlockingBottom);
        }

        protected override PlayerAnimation _animation => PlayerAnimation.BlockingBottom;
    }
}