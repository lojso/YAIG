using System;
using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(Camera))]
    public class PlayerFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 _followOffset;
        
        private Camera _camera;
        private Transform _playerTransform;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if(_playerTransform == null)
                return;

            transform.position = _playerTransform.position + _followOffset;
        }
    }
}