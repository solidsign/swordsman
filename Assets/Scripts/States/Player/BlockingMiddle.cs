namespace Game.States.Player
{
    public class BlockingMiddle : Blocking
    {
        public override void Execute()
        {
            _animator.SetTrigger(nameof(BlockingMiddle));
        }

        public override string ToString()
        {
            return nameof(BlockingMiddle);
        }
    }
}