namespace Game.States.Player
{
    public class AttackedMiddle : Attacked
    {
        public override string ToString()
        {
            return nameof(AttackedMiddle);
        }

        public override bool VerifyNextState(string state)
        {
            return state == nameof(Dead) || state == nameof(BlockingMiddle);
        }
    }
}