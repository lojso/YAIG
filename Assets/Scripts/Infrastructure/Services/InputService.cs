using Infrastructure.Services.Abstract;
using UnityEngine;

namespace Infrastructure.Services
{
    public class InputService : IInputService
    {
        public float GetHorizontalInput()
        {
            return Input.GetAxisRaw("Horizontal");
        }

        public bool IsAttackPressed()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
}