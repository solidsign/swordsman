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

        public void Attack(StateHandler attacker, Direction direction, float attackDistance)
        {
            if (!CheckAttackDistance(attackDistance)) return;
            if(attacker == player) ai.SetState(nameof(Attacked) + direction.ToString());
            if(attacker == ai) player.SetState(nameof(Attacked) + direction.ToString());
        }
    }
}