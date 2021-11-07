using UnityEngine;

namespace Game.States.Player
{
    public class MovingLeft : Moving
    {
        public MovingLeft(StateHandler stateHandler) : base(stateHandler)
        {
        }
        
        public override void Execute()
        {
            _rigidbody.MovePosition(_rigidbody.position + _speed * Time.deltaTime * Vector2.left);
        }

        public override string ToString()
        {
            return nameof(MovingLeft);
        }
    }
}