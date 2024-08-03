using SlotMachine.Business.Common.UseCases;
using UnityEngine;
using Zenject;

namespace SlotMachine.Game.Common.Hit
{
    public class Hit : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private AudioSource _audioSource;

        private HitUseCase _hitUseCase;

        [Inject]
        public void Construct(HitUseCase hitUseCase)
        {
            _hitUseCase = hitUseCase;
        }

        public void OnTap()
        {
            var isSuccess = _hitUseCase.Execute();
            if (!isSuccess)
            {
                return;
            }

            _animator.Play("Shake");
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}

