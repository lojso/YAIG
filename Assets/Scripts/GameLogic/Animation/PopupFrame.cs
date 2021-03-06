using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic.Animation
{
    public class PopupFrame : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void SetImage(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        public void FadeOut(float delaySec, float animationLength)
        {
            StartCoroutine(FadeOutRoutine(delaySec, animationLength));
        }

        private IEnumerator FadeOutRoutine(float delaySec, float animationLengthMs)
        {
            SetAlpha(_image, 1f);
            
            yield return new WaitForSeconds(delaySec);
            
            var normalizedAnimationTime = 0f;
            while (normalizedAnimationTime <= 1f)
            {
                SetAlpha(_image, 1 - normalizedAnimationTime);
                normalizedAnimationTime += Time.deltaTime;
                yield return null;
            }
            Destroy(this.gameObject);
        }

        private void SetAlpha(Image image, float aplha)
        {
            var color = image.color;
            color.a = aplha;
            image.color = color;
        }
    }
}