using System.Collections;

namespace Infrastructure.Services.Abstract
{
    public interface IRuntimeService : IService
    {
        void StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(IEnumerator coroutine);
    }
}