using DG.Tweening;
using UnityEngine;

namespace Code.Runtime.Gameplay.View.UI
{
    internal class PunchAnimator : MonoBehaviour
    {
        [SerializeField] private RectTransform _target;
        [SerializeField] public float _targetScale = 1.1f;
        [SerializeField] public float _duration = 0.2f;
        private Tweener _currentTweener;

        public void Animate()
        {
            if (_currentTweener != null)
                _currentTweener?.Kill(true)

                    ;
            _currentTweener = _target
                .DOPunchScale(Vector3.one * _targetScale, _duration)
                .SetEase(Ease.InOutCubic)
                .SetLink(gameObject);

        }
    }
}