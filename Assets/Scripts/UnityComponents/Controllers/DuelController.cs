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
        
        private BodyPosition _positionBody1;
        private BodyPosition _positionBody2;
        private void Awake()
        {
            player.gameObject.AddComponent<DuelControllerInstance>().DuelController = this;
            ai.gameObject.AddComponent<DuelControllerInstance>().DuelController = this;
            player.Init(PlayerInput.GetInstance());
            ai.Init(new AIInput(this));
            _positionBody1 = player.GetComponent<BodyPosition>();
            _positionBody2 = ai.GetComponent<BodyPosition>();
        }

        public bool CheckAttackDistance(float attackDistance) => Distance() <= attackDistance;

        public float Distance() => Vector3.Distance(_positionBody1.Value, _positionBody2.Value);
        public string GetPlayerState() => player.GetCurrentState();

        public void Attack(SwordsmanStateHandler attacker, Direction direction, float attackDistance)
        {
            if (!CheckAttackDistance(attackDistance)) return;
            
            SwordsmanStateHandler attacked;
            if (attacker == player) attacked = ai;
            else if (attacker == ai) attacked = player;
            else return;
            
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