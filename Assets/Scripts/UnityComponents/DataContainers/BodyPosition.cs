using System;
using UnityEngine;

namespace Game
{
    public class BodyPosition : MonoBehaviour
    {
        [SerializeField] private Vector2 offset;

        public Vector2 Value => (Vector2)transform.position + offset;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(Value + Vector2.up, Value + Vector2.down);
        }
    }
}