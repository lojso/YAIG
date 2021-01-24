using System.Collections;
using UnityEngine;

namespace Infrastructure.Services.Abstract
{
    public interface IRuntimeService : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }
}