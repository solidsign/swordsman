using Game.Extra;

namespace Game.States.Player
{
    public class BlockingBottom : Blocking
    {
        public override void Enter()
        {
            _animator.SetAnimation(PlayerAnimation.BlockingBottom);
        }

        public override string ToString()
        {
            return nameof(BlockingBottom);
        }
    }
}