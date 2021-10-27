namespace Game.States.Player
{
    public class BlockingBottom : Blocking
    {
        public override void Execute()
        {
            _animator.SetTrigger(nameof(BlockingBottom));
        }

        public override string ToString()
        {
            return nameof(BlockingBottom);
        }
    }
}