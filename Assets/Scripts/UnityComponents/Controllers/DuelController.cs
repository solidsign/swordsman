using UnityEngine;

namespace Game
{
    public class DuelController : MonoBehaviour
    {
        [SerializeField] private Transform opponent1;
        [SerializeField] private Transform opponent2;

        private void Awake()
        {
            opponent1.gameObject.AddComponent<DuelControllerInstance>().DuelController = this;
            opponent2.gameObject.AddComponent<DuelControllerInstance>().DuelController = this;
        }

        public bool TryAttack(float attackDistance)
        {
            return Vector3.Distance(opponent1.position, opponent2.position) <= attackDistance;
        }
    }
}