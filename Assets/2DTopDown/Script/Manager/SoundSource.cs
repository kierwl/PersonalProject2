using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Topdown
{
    public class SoundSource : MonoBehaviour
    {
        private AudioSource _audioSource;

        public void Play(AudioClip clip, float soundEffectVolue, float soundEffectPitchVariance)
        {
            if(_audioSource == null)
            
                _audioSource = GetComponent<AudioSource>();
            CancelInvoke();
            _audioSource.clip = clip;
            _audioSource.volume = soundEffectVolue;
            _audioSource.Play();
            _audioSource.pitch = 1f + Random.Range(-soundEffectPitchVariance, soundEffectPitchVariance);

            Invoke("Disable", clip.length +2);
        }

        public void Disable()
        {
            _audioSource?.Stop();
            Destroy(this.gameObject);
        }

    }

}

