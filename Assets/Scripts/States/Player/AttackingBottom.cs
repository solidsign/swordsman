using Game.Extra;

namespace Game.States.Player
{
    public class AttackingBottom : Attacking
    {
        protected override Direction _direction => Direction.Bottom;
        protected override PlayerAnimation _attackAnimation => PlayerAnimation.AttackingBottom;
        protected override PlayerAnimation _prepareAnimation => PlayerAnimation.PrepareAttackBottom;

        public override string ToString()
        {
            return nameof(AttackingBottom);
        }
    }
}