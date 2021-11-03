using UnityEngine;

namespace Game.Extra
{
    public class AIDuelLooker
    {
        private SwordsmanStateHandler _player;
        private SwordsmanStateHandler _ai;
        public AIDuelLooker(SwordsmanStateHandler player, SwordsmanStateHandler ai)
        {
            _player = player;
            _ai = ai;
        }

        public bool PlayerCanAttack()
        {
            var distance = Vector2.Distance(_player.Weapon.AttackPointPosition, _ai.BodyPosition.Value);
            return distance <= _player.Weapon.AttackDistance;
        }

        public bool PlayerIsToTheLeft() => _player.BodyPosition.Value.x < _ai.BodyPosition.Value.x;

        public bool AICanAttack()
        {
            var distance = Vector2.Distance(_ai.Weapon.AttackPointPosition, _player.BodyPosition.Value);
            return distance <= _ai.Weapon.AttackDistance;
        }

        public bool PlayerIsAttacking() => _player.GetCurrentState().Contains(nameof(Game.States.Player.Attacking));

        public bool AIIsAttacking() => _ai.GetCurrentState().Contains(nameof(Game.States.Player.Attacking));
        public Direction GetPlayersAttackDirection()
        {
            string state = _player.GetCurrentState();
            if (state.Contains(Direction.Up.ToString())) return Direction.Up;
            if (state.Contains(Direction.Middle.ToString())) return Direction.Middle;
            return Direction.Bottom;
        }
    }
}