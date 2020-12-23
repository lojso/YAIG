using UnityEngine;

namespace GameLogic
{
    public class CreatureMover
    {
        private readonly Quaternion _defaultPosition = Quaternion.Euler(0, 0, 0);
        private readonly Quaternion _invertedPosition = Quaternion.Euler(0, 180, 0);
        private readonly Rigidbody2D _rigidbody;

        private bool IsRotatedRight => _rigidbody.transform.right.x > 0;

        public CreatureMover(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Move(Vector2 direction, float speed)
        {
            var velocity = _rigidbody.velocity;
            velocity.x = direction.x * speed;
            _rigidbody.velocity = velocity;
        }
        
        public void RotateDirection(Vector2 direction)
        {
            if(direction.x < 0)
            {
                RotateToLeft();
            }
            else
            {
                RotateToRight();
            }
        }

        private void RotateToRight() => 
            _rigidbody.transform.rotation = _defaultPosition;

        private void RotateToLeft() => 
            _rigidbody.transform.rotation = _invertedPosition;
    }
}