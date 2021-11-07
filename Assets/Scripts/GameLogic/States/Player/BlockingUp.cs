using Game.Extra;

namespace Game.States.Player
{
    public class BlockingUp : Blocking
    {
        public BlockingUp(StateHandler stateHandler) : base(stateHandler)
        {
        }

        public override string ToString()
        {
            return nameof(BlockingUp);
        }

        protected override PlayerAnimation _animation => PlayerAnimation.BlockingUp;
    }
}