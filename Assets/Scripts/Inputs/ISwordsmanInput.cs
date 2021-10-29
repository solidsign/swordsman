namespace Game.Inputs
{
    public interface ISwordsmanInput
    {
        bool StartMoveRight();
        bool StartMoveLeft();
        bool StopMoveRight();
        bool StopMoveLeft();
        bool BlockUp();
        bool BlockMiddle();
        bool BlockBottom();
        bool AttackUp();
        bool AttackMiddle();
        bool AttackBottom();
    }
}