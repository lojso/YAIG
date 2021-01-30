using Infrastructure.Services.Abstract;
using Infrastructure.Services.Abstract.Factories;
using UnityEngine;

namespace Infrastructure.Services
{
    public class CutsceneService : ICutsceneService
    {
        private static readonly int DickButtTrigger = Animator.StringToHash("dickButt");
        
        private Animator _animator;

        public CutsceneService(IUiFactory uiFactory)
        {
            if (uiFactory.Ui != null)
            {
                _animator = uiFactory.Ui.Cutscene.GetComponent<Animator>();
            }
            else
            {
                uiFactory.OnUiCreated += ui => _animator = ui.Cutscene.GetComponent<Animator>();
            }
        }
        
        public void PlayDickButt()
        {
            if (_animator == null)
            {
                Debug.LogError("CutscenesService: cant play cutscenes without animator");
                return;
            }
            
            _animator.SetTrigger(DickButtTrigger);
        }
    }
}