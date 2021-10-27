namespace Game.States.Player
{
    public class AttackedUp : Attacked
    {
        public override string ToString()
        {
            return nameof(AttackedUp);
        }

        public override bool VerifyNextState(string state)
        {
            return state == nameof(Dead) || state == nameof(BlockingUp);
        }
    }
}