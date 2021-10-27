namespace Game.States.Player
{
    public class BlockingUp : Blocking
    {
        public override void Execute()
        {
            _animator.SetTrigger(nameof(BlockingUp));
        }

        public override string ToString()
        {
            return nameof(BlockingUp);
        }
    }
}