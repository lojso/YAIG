using UnityEngine;

namespace Infrastructure.Services.Abstract.Factories
{
    public interface ICameraFactory : IService
    {
        Camera CreateCamera();
    }
}