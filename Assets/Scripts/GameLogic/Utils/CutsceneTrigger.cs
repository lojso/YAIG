using System;
using GameLogic.Helpers;
using Infrastructure.Services;
using Infrastructure.Services.Abstract;
using UnityEngine;

namespace GameLogic
{
    public class CutsceneTrigger : MonoBehaviour
    {
        [SerializeField] private Trigger _trigger;
        private ICutsceneService _cutscenePlayer;

        private void Awake()
        {
            _cutscenePlayer = ServicesContainer.Instance.Single<ICutsceneService>();

            _trigger.OnTriggerEnter += TriggerEnterHandler;
        }

        private void TriggerEnterHandler(GameObject obj)
        {
            if(obj.GetComponent<Player.Player>())
                _cutscenePlayer.PlayDickButt();
        }
    }
}