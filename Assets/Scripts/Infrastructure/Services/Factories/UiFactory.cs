using System;
using Infrastructure.Services.Abstract.Factories;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Services.Factories
{
    public class UiFactory : IUiFactory
    {
        public event Action<Canvas> OnCanvasCreated;
        
        public Canvas Canvas { get; private set; }

        public Canvas CreateCanvas()
        {
            var canvasPrefab = Resources.Load<Canvas>(AssetsPath.Canvas);
            Canvas = Object.Instantiate(canvasPrefab);
            OnCanvasCreated?.Invoke(Canvas);
            return Canvas;
        }
    }
}