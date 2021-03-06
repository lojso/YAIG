using UnityEngine;

namespace Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "popupAnimationsList", menuName = "Animation/Popup Animation List", order = 0)]
    public class PopupAnimationsList : ScriptableObject
    {
        public PopupAnimationData TestAnimation;
        public PopupAnimationData AnotherTestAnimation;
        public PopupAnimationData PlaceholderAnimation;
    }
}