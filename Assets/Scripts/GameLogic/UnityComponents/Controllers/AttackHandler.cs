using Game.Extra;
using Game.Inputs;
using Game.States.Player;
using UnityEngine;

namespace Game
{
    public class AttackHandler
    {
        private readonly SwordsmanStateHandler _player;
        private readonly SwordsmanStateHandler _ai;
        private readonly DuelController _duel;
        
        private AIDuelLooker _looker;

        public AttackHandler(SwordsmanStateHandler player, SwordsmanStateHandler ai, DuelController duel)
        {
            _player = player;
            _ai = ai;
            _duel = duel;
        }

        public void Attack(SwordsmanStateHandler attacker, Direction direction, float attackDistance)
        {
            SwordsmanStateHandler attacked;
            if (attacker == _player) attacked = _ai;
            else if (attacker == _ai) attacked = _player;
            else
            {
                #if UNITY_EDITOR
                Debug.Log(attacker.name + " tried to attack but it's not in AttackHandler");
                #endif
                return;
            }

            var distance = Vector2.Distance(attacker.Weapon.AttackPointPosition, attacked.BodyPosition.Value);
            if (distance > attacker.Weapon.AttackDistance) return;
            
            attacked.SetState(nameof(Attacked) + direction.ToString());
            
            if (!attacked.GetCurrentState().Contains(nameof(Attacked))) return;
            _duel.HandleDuelEnd(attacked);
        }
    }
}