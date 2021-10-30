using System;
using System.Collections;
using Game.Extra;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Game
{
    public class DuelEndEffect : MonoBehaviour
    {
        [Range(0f, PlayerAnimationConfiguration.AttackStateTime)] [SerializeField] private float enableTime;
        [SerializeField] private float disableTime;

        private PostProcessVolume _volume;
        private float _newWeight = 0f;

        private void Awake()
        {
            _volume = GetComponent<PostProcessVolume>();
        }

        private IEnumerator UpdateWeight(float time)
        {
            if (Math.Abs(_newWeight - _volume.weight) < 0.05f) yield break;
            float startValue = _volume.weight;
            float t = 0f;
            while (t < 1f)
            {
                _volume.weight = Mathf.Lerp(startValue, _newWeight, t);
                t += Time.deltaTime / time;
            }
        }

        public void EnableEffect()
        {
            StopAllCoroutines();
            _newWeight = 1f;
            StartCoroutine(UpdateWeight(enableTime));
        }

        public void DisableEffect()
        {
            StopAllCoroutines();
            _newWeight = 0f;
            StartCoroutine(UpdateWeight(disableTime));
        }
    }
}
