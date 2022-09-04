using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace SortItems
{
    public class AnimateVolumeWinFail : MonoBehaviour
    {
        [SerializeField] private Volume _volume;
        [SerializeField] private float _animationTime = 0.9f;
        private bool _isAnimate=false;
        private float _elapsedTime;

        public void Animate()
        {
            if (_isAnimate) return;
            _isAnimate=true;
            _elapsedTime=0f;
            StartCoroutine(DoAnimateVolume());
        }

        protected IEnumerator DoAnimateVolume()
        {
            while (_elapsedTime<_animationTime)
            {
                yield return new WaitForEndOfFrame();
                _volume.weight = Mathf.Sin(Mathf.PI*_elapsedTime/_animationTime);
                _elapsedTime+=Time.deltaTime;
            }
            _isAnimate=false;
        }
    }
}
