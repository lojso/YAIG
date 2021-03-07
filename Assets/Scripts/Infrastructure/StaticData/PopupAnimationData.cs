using System;
using UnityEngine;

namespace Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "popupAnimationData", menuName = "Animation/Popup Animation", order = 0)]
    public class PopupAnimationData : ScriptableObject
    {
        public PopupAnimationFrame[] animationFrames;
    }

    [Serializable]
    public struct PopupAnimationFrame
    {
        public float showDelaySec;
        public Sprite frameSprite;
        public float frameLengthSec;
        public float fadeOutTimeSec;
    }
}