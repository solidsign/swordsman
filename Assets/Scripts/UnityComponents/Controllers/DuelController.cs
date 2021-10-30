using Game.Extra;
using Game.Inputs;
using Game.States.Player;
using UnityEngine;

namespace Game
{
    public class DuelController : MonoBehaviour
    {
        [SerializeField] private SwordsmanStateHandler player;
        [SerializeField] private SwordsmanStateHandler ai;

        [SerializeField] private DuelEndEffect duelEndEffect;
        private void Awake()
        {
            player.gameObject.AddComponent<DuelControllerInstance>().DuelController = this;
            ai.gameObject.AddComponent<DuelControllerInstance>().DuelController = this;
            player.Init(PlayerInput.GetInstance());
            ai.Init(new AIInput(this));
        }

        
        public string GetPlayerState() => player.GetCurrentState();

        public void Attack(SwordsmanStateHandler attacker, Direction direction, float attackDistance)
        {
            SwordsmanStateHandler attacked;
            if (attacker == player) attacked = ai;
            else if (attacker == ai) attacked = player;
            else return;

            var distance = Vector2.Distance(attacker.Weapon.AttackPointPosition, attacked.BodyPosition.Value);
            if (distance > attacker.Weapon.AttackDistance) return;
            
            attacked.SetState(nameof(Attacked) + direction.ToString());
            
            if (!attacked.GetCurrentState().Contains(nameof(Attacked))) return;
            duelEndEffect.EnableEffect();
            Invoke(nameof(DisableEffect), PlayerAnimationConfiguration.DeathTime);
        }

        private void DisableEffect()
        {
            duelEndEffect.DisableEffect();
        }
    }
}