using System;
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
        private readonly Action<SwordsmanStateHandler> _handleDuelEnd;

        public AttackHandler(SwordsmanStateHandler player, SwordsmanStateHandler ai, Action<SwordsmanStateHandler> handleDuelEnd)
        {
            _player = player;
            _ai = ai;
            _handleDuelEnd = handleDuelEnd;
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
            _handleDuelEnd(attacked);
        }
    }
}