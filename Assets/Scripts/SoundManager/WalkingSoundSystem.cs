using Player.Movement;
using UnityEngine;
using Zenject;

namespace SoundManager
{
    public class WalkingSoundSystem : MonoBehaviour
    {
        [Inject] private SimpleControls _controls;
        public AudioClip[] stepSounds;
        public float stepInterval = 0.5f;
        private AudioSource audioSource;

        private int currentStepIndex = 0;
        private float nextStepTime = 0f;

        [SerializeField] private GroundChecker _groundChecker;
        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if(!_groundChecker.IsGrounded())
                return;
            
            var move = _controls.gameplay.move.ReadValue<Vector2>();
            if (move.magnitude > 0)
            {
                if (Time.time >= nextStepTime)
                {
                    PlayNextStepSound();
                    nextStepTime = Time.time + stepInterval;
                }
            }
        }

        private void PlayNextStepSound()
        {
            audioSource.PlayOneShot(stepSounds[currentStepIndex]);

            currentStepIndex++;

            if (currentStepIndex >= stepSounds.Length)
            {
                currentStepIndex = 0;
            }
        }
    }
}
