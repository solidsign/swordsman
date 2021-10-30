using UnityEngine;

namespace Game
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float attackDistance;
        [SerializeField] private float prepareForAttackTime;
        [SerializeField] private float attackPointOffsetX;
        public float AttackDistance => attackDistance;
        public float PrepareForAttackTime => prepareForAttackTime;
        public Vector2 AttackPointPosition => transform.position + attackPointOffsetX * Vector3.right;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + attackPointOffsetX * Vector3.right, transform.position + attackDistance * transform.right);
        }
    }
}