using Game.Extra;

namespace Game.States.Player
{
    public class BlockingBottom : Blocking
    {
        public BlockingBottom(StateHandler stateHandler) : base(stateHandler)
        {
        }

        public override string ToString()
        {
            return nameof(BlockingBottom);
        }

        protected override PlayerAnimation _animation => PlayerAnimation.BlockingBottom;
    }
}