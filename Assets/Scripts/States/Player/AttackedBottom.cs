namespace Game.States.Player
{
    public class AttackedBottom : Attacked
    {
        public override string ToString()
        {
            return nameof(AttackedBottom);
        }

        public override bool VerifyNextState(string state)
        {
            return state == nameof(Dead) || state == nameof(BlockingBottom);
        }
    }
}