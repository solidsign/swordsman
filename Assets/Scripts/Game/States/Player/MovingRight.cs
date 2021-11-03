using UnityEngine;

namespace Game.States.Player
{
    public class MovingRight : Moving
    {
        public override void Execute()
        {
            _rigidbody.MovePosition(_rigidbody.position + _speed * Time.deltaTime * Vector2.right);
        }

        public override string ToString()
        {
            return nameof(MovingRight);
        }
    }
}