using Game.Extra;

namespace Game.States.Player
{
    public class BlockingMiddle : Blocking
    {
        public override void Enter()
        {
            _animator.SetAnimation(PlayerAnimation.BlockingMiddle);
        }

        public override string ToString()
        {
            return nameof(BlockingMiddle);
        }
    }
}