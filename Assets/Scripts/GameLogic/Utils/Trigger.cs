using System;
using UnityEngine;

namespace GameLogic.Helpers
{
    [RequireComponent(typeof(Collider2D))]
    public class Trigger : MonoBehaviour
    {
        public event Action<GameObject> OnTriggerEnter;
        public event Action<GameObject> OnTriggerExit;

        private void OnTriggerEnter2D(Collider2D other) => 
            OnTriggerEnter?.Invoke(other.gameObject);

        private void OnTriggerExit2D(Collider2D other) => 
            OnTriggerExit?.Invoke(other.gameObject);
    }
}