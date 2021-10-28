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

        private Transform t1;
        private Transform t2;
        private void Awake()
        {
            player.gameObject.AddComponent<DuelControllerInstance>().DuelController = this;
            ai.gameObject.AddComponent<DuelControllerInstance>().DuelController = this;
            player.Init(PlayerInput.GetInstance());
            ai.Init(new AIInput(ai.GetComponent<AccessToComponentsNeededForAI>()));
        }

        private void Start()
        {
            t1 = player.transform;
            t2 = ai.transform;
        }

        public bool CheckAttackDistance(float attackDistance)
        {
            return Vector3.Distance(t1.position, t2.position) <= attackDistance;
        }

        public void Attack(StateHandler attacker, Direction direction)
        {
            if(attacker == player) ai.SetState(nameof(Attacked) + direction.ToString());
            if(attacker == ai) player.SetState(nameof(Attacked) + direction.ToString());
        }
    }
}