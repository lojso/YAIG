using System;
using System.Collections;
using Infrastructure.Services.Abstract;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services
{
    public class SceneLoader : ISceneLoader
    {
        private readonly IRuntimeService _runtimeService;

        public SceneLoader(IRuntimeService runtimeService)
        {
            _runtimeService = runtimeService;
        }
        
        public void Load(string name, Action onLoaded = null) =>
            _runtimeService.StartCoroutine(LoadScene(name, onLoaded));
        
        private static IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            // if (SceneManager.GetActiveScene().name == name)
            // {
            //     onLoaded?.Invoke();
            //     yield break;
            // }
      
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (!waitNextScene.isDone)
                yield return null;
      
            onLoaded?.Invoke();
        }
    }
}