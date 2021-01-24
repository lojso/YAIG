using System;
using System.Collections;
using Infrastructure.Services.Abstract;
using UnityEngine;

namespace Infrastructure.Services
{
    public class RuntimeService : MonoBehaviour, IRuntimeService
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public Coroutine StartCoroutine(IEnumerator coroutine) => 
            base.StartCoroutine(coroutine);

        public void StopCoroutine(Coroutine coroutine) => 
            base.StopCoroutine(coroutine);
    }
}