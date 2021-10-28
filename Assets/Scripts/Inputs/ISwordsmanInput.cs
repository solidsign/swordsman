namespace Game.Inputs
{
    public interface ISwordsmanInput
    {
        bool MoveRight();
        bool MoveLeft();
        bool BlockUp();
        bool BlockMiddle();
        bool BlockBottom();
        bool AttackUp();
        bool AttackMiddle();
        bool AttackBottom();
    }
}