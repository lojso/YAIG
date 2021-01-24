using System.Collections;
using Infrastructure.Services.Abstract;
using UnityEngine;

namespace Infrastructure.Services
{
    public abstract class ShakeService
    {
        protected abstract Transform Transform { get; set; }

        private IRuntimeService _runtimeService;
        private Vector3 _positionOffset;
        private float _angleOffset;
        private Coroutine _positionShakeRoutine;
        private Coroutine _rotationShakeRoutine;

        public ShakeService(IRuntimeService runtimeService)
        {
            _runtimeService = runtimeService;
        }

        public void ShakePosition(float force, float duration)
        {
            StopShake();
            _positionShakeRoutine = _runtimeService.StartCoroutine(ShakePositionRoutine(force, duration));
            OnShakePosition();
        }

        public void ShakeRotation(float force, float duration)
        {
            StopShake();
            _rotationShakeRoutine = _runtimeService.StartCoroutine(ShakeRotationRoutine(force, duration));
            OnShakeRotation();
        }

        public void StopShake()
        {
            _runtimeService.StopCoroutine(_positionShakeRoutine);
            _runtimeService.StopCoroutine(_rotationShakeRoutine);
            DropPositionOffset();
            DropRotationOffset();
            _angleOffset = 0f;
            _positionOffset = Vector3.zero;

            OnStopShake();
        }

        private IEnumerator ShakePositionRoutine(float force, float duration)
        {
            var time = duration;
            _positionOffset = Vector3.zero;
            while (time > 0)
            {
                DropPositionOffset();
                _positionOffset = new Vector3(Random.Range(-force, force),
                    Random.Range(-force, force),
                    0);
                Transform.localPosition += _positionOffset;
                time -= Time.deltaTime;
                yield return null;
            }
            DropPositionOffset();
            _positionOffset = Vector3.zero;
            OnStopShake();
        }

        private IEnumerator ShakeRotationRoutine(float force, float duration)
        {
            var time = duration;
            _angleOffset = 0f;
            while (time > 0)
            {
                DropRotationOffset();
                _angleOffset = Random.Range(-force, force);
                Transform.Rotate(Vector3.forward, _angleOffset);
                time -= Time.deltaTime;
                yield return null;
            }
            DropRotationOffset();
            _angleOffset = 0f;
            OnStopShake();
        }

        private void DropRotationOffset() => 
            Transform.Rotate(Vector3.forward, -_angleOffset);

        private void DropPositionOffset() => 
            Transform.localPosition -= _positionOffset;
        
        protected virtual void OnShakePosition() { }
        protected virtual void OnShakeRotation() { }
        protected virtual void OnStopShake() { }
    }
}