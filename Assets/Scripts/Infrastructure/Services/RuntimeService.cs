﻿using System;
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

        public void StartCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }

        public void StopCoroutine(IEnumerator coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}