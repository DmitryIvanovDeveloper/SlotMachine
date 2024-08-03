using UnityEngine;
using UnityEngine.UI;
using Zenject;

using SlotMachine.Business.Domain.State;
using SlotMachine.Game.Domain.State.Events;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using SlotMachine.Game.Util.Extensions;
using TMPro;
using SlotMachine.Business.Domain.Inventory;
using SlotMachine.Business.Domain.State.UseCase;

namespace SlotMachine.Game.Domain.State
{
    //TODO: Rename to Health
    public class State : MonoBehaviour
    {
        [SerializeField]
        private Image _healthSlider;
        [SerializeField]
        private GameObject _levelCompleted;

        [SerializeField]
        private AudioClip _lightAudioClip;
        [SerializeField]
        private AudioClip _brokenSound;

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
        private StateRepairUseCase _stateRepairUseCase;
        private IInventoryInfo _inventoryInfo;
        [Inject]
        public void Construct(
            IStateInfo stateInfo,
            IInventoryInfo inventoryInfo,
            StateRepairUseCase stateRepairUseCase)
        {
            _stateInfo = stateInfo;
            _stateRepairUseCase = stateRepairUseCase;
            _inventoryInfo = inventoryInfo;
        }

        private void Start()
        {
            _stateInfo.OnStateChanged += UpdateView;
        }

        public void UpdateView()
        {
            var stateImage = _stateImages.FirstOrDefault(stateImage => stateImage.StateType == _stateInfo.CurrentStateType);
            if (stateImage == null)
            {
                throw new Exception($"The state image doesn't exist for {_stateInfo.CurrentStateType} stateType");
            }

            _state.sprite = stateImage.Image;

            var hitGameObject = Instantiate(_hitPrefab, _hits);

            var num = hitGameObject
                .FindChildOrThrow("Num")
                .GetComponentOrThrow<TextMeshProUGUI>()
            ;


            if (_stateInfo.CurrentStateType == Business.Common.StateType.HalfBroken)
            {
                _audioSource.Play();
            }
            if (_stateInfo.CurrentStateType == Business.Common.StateType.Broken)
            {
                _audioSource.PlayOneShot(_brokenSound);
                _audioSource.Stop();
            }

            _healthSlider.fillAmount = (float)_stateInfo.HealthInPercentage / 100f;

            num.text = $"+ {_inventoryInfo.SelectedWeapon.GetDamage()}";
            hitGameObject.transform.localPosition = Input.mousePosition;

            UnderRepair();
        }


        private void UnderRepair()
        {
            var isBroken = _stateInfo.CurrentStateType == Business.Common.StateType.Broken;

            _levelCompleted.SetActive(isBroken);

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
            _stateRepairUseCase.Execute();
            _slider.fillAmount = (float)_stateInfo.HealthInPercentage / 100f;
        }
    }
}
