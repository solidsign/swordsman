using Game.Extra;

namespace Game.States.Player
{
    public class BlockingUp : Blocking
    {
        public override void Enter()
        {
            _animator.SetAnimation(PlayerAnimation.BlockingUp);
        }

        public override string ToString()
        {
            return nameof(BlockingUp);
        }
    }
}