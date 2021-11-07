using Game.Extra;

namespace Game.States.Player
{
    public class AttackingUp : Attacking
    {
        protected override Direction _direction => Direction.Up;
        protected override PlayerAnimation _attackAnimation => PlayerAnimation.AttackingUp;
        protected override PlayerAnimation _prepareAnimation => PlayerAnimation.PrepareAttackUp;
        public AttackingUp(SwordsmanStateHandler stateHandler) : base(stateHandler)
        {
        }
        public override string ToString()
        {
            return nameof(AttackingUp);
        }
    }
}