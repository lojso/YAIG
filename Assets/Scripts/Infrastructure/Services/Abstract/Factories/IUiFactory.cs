using System;
using UnityEngine;

namespace Infrastructure.Services.Abstract.Factories
{
    public interface IUiFactory : IService
    {
        event Action<Canvas> OnCanvasCreated;
        Canvas Canvas { get; }
        
        Canvas CreateCanvas();
    }
}