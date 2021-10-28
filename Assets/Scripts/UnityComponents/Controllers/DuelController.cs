using Game.Extra;
using Game.States.Player;
using UnityEngine;

namespace Game
{
    public class DuelController : MonoBehaviour
    {
        [SerializeField] private StateHandler opponent1;
        [SerializeField] private StateHandler opponent2;

        private Transform t1;
        private Transform t2;
        private void Awake()
        {
            opponent1.gameObject.AddComponent<DuelControllerInstance>().DuelController = this;
            opponent2.gameObject.AddComponent<DuelControllerInstance>().DuelController = this;
        }

        private void Start()
        {
            t1 = opponent1.transform;
            t2 = opponent2.transform;
        }

        public bool CheckAttackDistance(float attackDistance)
        {
            return Vector3.Distance(t1.position, t2.position) <= attackDistance;
        }

        public void Attack(StateHandler attacker, Direction direction)
        {
            if(attacker == opponent1) opponent2.SetState(nameof(Attacked) + direction.ToString());
            if(attacker == opponent2) opponent1.SetState(nameof(Attacked) + direction.ToString());
        }
    }
}