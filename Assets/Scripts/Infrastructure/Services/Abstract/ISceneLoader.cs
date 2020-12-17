using System;

namespace Infrastructure.Services.Abstract
{
    public interface ISceneLoader : IService
    {
        void Load(string name, Action onLoaded = null);
    }
}