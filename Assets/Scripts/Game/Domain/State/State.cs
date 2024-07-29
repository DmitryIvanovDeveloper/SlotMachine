using UnityEngine;
using UnityEngine.UI;
using Zenject;

using SlotMachine.Business.Domain.State;
using SlotMachine.Game.Domain.State.Events;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;

namespace SlotMachine.Game.Domain.State
{
    public class State : MonoBehaviour
    {
        [SerializeField]
        private GameObject _underRepair;

        [SerializeField]
        private AudioClip _lightAudioClip;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private Image _slider;

        [SerializeField]
        private GameObject _hitPrefab;
        [SerializeField]
        private Transform _hits;

        [SerializeField]
        private Image _state;
        [SerializeField]
        private List<StateImage> _stateImages;

        private IStateInfo _stateInfo;
        private StateAddDamageEvent _stateAddDamageEvent;
        private StateRepairEvent _stateRepairEvent;

        [Inject]
        public void Construct(IStateInfo stateInfo, StateAddDamageEvent stateAddDamageEvent, StateRepairEvent stateRepairEvent)
        {
            _stateInfo = stateInfo;
            _stateAddDamageEvent = stateAddDamageEvent;
            _stateRepairEvent = stateRepairEvent;
        }

        private void Start()
        {
            UpdateView();
        }

        public void UpdateView()
        {
            var stateImage = _stateImages.FirstOrDefault(stateImage => stateImage.StateType == _stateInfo.CurrentStateType);
            if (stateImage == null)
            {
                throw new Exception($"The state image doesn't exist for {_stateInfo.CurrentStateType} stateType");
            }

            _state.sprite = stateImage.Image;

            if (_stateInfo.CurrentStateType == Business.Common.StateType.HalfBroken && !_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
            else
            {
                _audioSource.Stop();
            }

            UnderRepair();
        }

        public async void Hit()
        {
            await _stateAddDamageEvent.Notify();

            var earnGameObject = Instantiate(_hitPrefab, _hits);
            earnGameObject.transform.position = Input.mousePosition;

            Debug.Log(Input.mousePosition.y);
        }

        private void UnderRepair()
        {
            var isBroken = _stateInfo.CurrentStateType == Business.Common.StateType.Broken;

            _underRepair.SetActive(isBroken);

            if (!isBroken)
            {
                StopCoroutine(Repair());
                return;
            }


            StartCoroutine(Repair());
        }

        private IEnumerator Repair()
        {
            yield return new WaitForSeconds(1);
            _stateRepairEvent.Notify();
            _slider.fillAmount = (float)_stateInfo.CurrentRepairInPercentage / 100f;
        }
    }
}
