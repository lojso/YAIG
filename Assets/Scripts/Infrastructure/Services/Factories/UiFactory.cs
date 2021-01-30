using System;
using Infrastructure.Services.Abstract.Factories;
using UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Services.Factories
{
    public class UiFactory : IUiFactory
    {
        public event Action<UiHolder> OnUiCreated;
        
        public UiHolder Ui { get; private set; }
        
        public UiHolder CreateUi()
        {
            var canvasPrefab = Resources.Load<UiHolder>(AssetsPath.Canvas);
            Ui = Object.Instantiate(canvasPrefab);
            Ui.Frame.SetActive(false);
            OnUiCreated?.Invoke(Ui);
            return Ui;
        }
    }
}