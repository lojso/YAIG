using Infrastructure.Services.Abstract;
using Infrastructure.Services.Abstract.Factories;
using UnityEngine;

namespace Infrastructure.Services.Animation
{
    public class CutsceneService : ICutsceneService
    {
        private static readonly int _dickButtTrigger = Animator.StringToHash("dickButt");
        private static readonly int _racoonTrigger = Animator.StringToHash("racoon");
        
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
            
            _animator.SetTrigger(_dickButtTrigger);
        }

        public void PlayPlayRacoon()
        {
            if (_animator == null)
            {
                Debug.LogError("CutscenesService: cant play cutscenes without animator");
                return;
            }
            
            _animator.SetTrigger(_racoonTrigger);
        }
    }
}