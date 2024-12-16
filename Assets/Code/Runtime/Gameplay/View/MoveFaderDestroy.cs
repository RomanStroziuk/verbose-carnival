using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace Code.Runtime.Gameplay.View
{
    public class MoveFaderDestroy : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField] 
        private float _duration = 1;

        [SerializeField] 
        private float _moveDeltaY = -1;
        
        public void Destroy() =>
        
                DOTween.Sequence()
                .Join(Fade())
                .Join(Move())
                .OnComplete(() => Destroy(gameObject))
                .Play();
        
        private Tween Move() =>
          gameObject
              .transform.
              DOMoveY(transform.position.y - _moveDeltaY, _duration)
              .SetEase(Ease.InOutCubic)
              .OnComplete(() => Destroy(gameObject));
              
        
        private TweenerCore<Color, Color, ColorOptions> Fade() =>
        
            _spriteRenderer
                .DOFade(0, _duration)
                .SetEase(Ease.InOutCubic)
                .SetLink(gameObject)
                .OnComplete(() => Destroy(gameObject));
        
    }
}