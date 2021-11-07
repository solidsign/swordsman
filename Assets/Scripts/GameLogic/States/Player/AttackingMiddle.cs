using Game.Extra;

namespace Game.States.Player
{
    public class AttackingMiddle : Attacking
    {
        protected override Direction _direction => Direction.Middle;
        protected override PlayerAnimation _attackAnimation => PlayerAnimation.AttackingMiddle;
        protected override PlayerAnimation _prepareAnimation => PlayerAnimation.PrepareAttackMiddle;
        public AttackingMiddle(SwordsmanStateHandler stateHandler) : base(stateHandler)
        {
        }
        public override string ToString()
        {
            return nameof(AttackingMiddle);
        }
    }
}