using UnityEngine;
using UnityEngine.UI;
using Zenject;

using SlotMachine.Business.Domain.State;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using SlotMachine.Game.Util.Extensions;
using TMPro;
using SlotMachine.Business.Domain.Inventory;
using SlotMachine.Business.Domain.State.UseCase;
using SlotMachine.Game.Common;
using SlotMachine.Business.Domain.Dtos;
using SlotMachine.Business.Common;

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

        private IGameContext _gameContext;
        private IStateInfo _stateInfo;
        private StateRepairUseCase _stateRepairUseCase;
        private IInventoryInfo _inventoryInfo;

        [Inject]
        public void Construct(
            IGameContext gameContext,
            IStateInfo stateInfo,
            IInventoryInfo inventoryInfo,
            StateRepairUseCase stateRepairUseCase)
        {
            _gameContext = gameContext;
            _stateInfo = stateInfo;
            _stateRepairUseCase = stateRepairUseCase;
            _inventoryInfo = inventoryInfo;
        }

        private void Start()
        {
            _stateImages = GetStateImages(_gameContext.Level.SlotMachine.StatesSlotMachine);

            _stateInfo.OnStateChanged += UpdateView;

            var newStateImage = _stateImages.FirstOrDefault(image => image.StateType == StateType.New);
            if (newStateImage == null)
            {
                throw new Exception("Error");
            }

            _state.sprite = newStateImage.Image;
            UpdateView();
        }

        private List<StateImage> GetStateImages(List<SlotMachineStateDto> slotMachineStates)
        {
            var statesImage = new List<StateImage>();

            foreach (var slotState in slotMachineStates)
            {
                Debug.Log(slotState.Image);

                var stateImage = new StateImage()
                {
                    StateType = slotState.StateType,
                    Image = ConvertUrlToSprite(slotState.Image)
                };

                statesImage.Add(stateImage);
            }

            return statesImage;
        }

        private Sprite ConvertUrlToSprite(byte[] imageBytes)
        {
            var texture = new Texture2D(2, 2, TextureFormat.BGRA32, false);
            texture.LoadImage(imageBytes);
            texture.Apply();
            return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }

        public void UpdateView()
        {
            var stateImage = _stateImages.FirstOrDefault(stateImage => stateImage.StateType == _stateInfo.CurrentStateType);
            if (stateImage == null)
            {
                throw new Exception($"The state image doesn't exist for {_stateInfo.CurrentStateType} stateType");
            }

            //_state.sprite = stateImage.Image;

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
