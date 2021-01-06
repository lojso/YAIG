using Infrastructure.Services;
using Infrastructure.Services.Abstract.Factories;
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

            var playerFactory = ServicesContainer.Instance.Single<IPlayerFactory>();
            
            _playerTransform = playerFactory.Player.transform;
            
            if (_playerTransform == null)
            {
                playerFactory.OnPlayerCreated += player => _playerTransform = player.transform;
            }
        }

        private void Update()
        {
            if(_playerTransform == null)
                return;

            transform.position = _playerTransform.position + _followOffset;
        }
    }
}