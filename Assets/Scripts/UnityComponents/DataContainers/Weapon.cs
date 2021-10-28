using UnityEngine;

namespace Game
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float attackDistance;
        [SerializeField] private float prepareForAttackTime;
        public float AttackDistance => attackDistance;
        public float PrepareForAttackTime => prepareForAttackTime;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + attackDistance * transform.right);
        }
    }
}