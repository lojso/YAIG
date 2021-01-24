using System;
using UI;
using UnityEngine;

namespace Infrastructure.Services.Abstract.Factories
{
    public interface IUiFactory : IService
    {
        event Action<UiHolder> OnUiCreated;
        UiHolder Ui { get; }
        
        UiHolder CreateUi();
    }
}