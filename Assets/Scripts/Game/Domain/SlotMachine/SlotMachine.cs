using UnityEngine;
using Zenject;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;

using SlotMachine.Game.Domain.SlotMachine.Events;
using SlotMachine.Business.Domain.SlotMachine;
using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.SlotMachine.UseCase;

namespace SlotMachine.Game.Domain.SlotMachine
{
    public class SlotMachine : MonoBehaviour
    {
        [SerializeField]
        private List<AudioClip> _slotSounds;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private GameObject _congratulation;

        [SerializeField]
        private List<Shape> _shapes;

        [SerializeField]
        private Image _shapeOne;
        [SerializeField]
        private Image _shapeTwo;
        [SerializeField]
        private Image _shapeThree;

        private float _elapseTime;
        private bool _isPlay;

        private bool _shapeOneRolling;
        private bool _shapeTwoRolling;
        private bool _shapeThreeRolling;


        private SlotMachinePlayUseCase _slotMachinePlayUseCase;
        private ISlotMachineInfo _slotMachineInfo;
  
        [Inject]
        public void Construct(ISlotMachineInfo slotMachineInfo,
            SlotMachinePlayUseCase slotMachinePlayUseCase
        {
            _slotMachinePlayUseCase = slotMachinePlayUseCase;
            _slotMachineInfo = slotMachineInfo;
        }

        private void Awake()
        {
            _slotMachineInfo.OnStartGame += StartGame;
            _slotMachineInfo.OnSlostChanged += ChangeSlot;
        }

        private void StartGame()
        {
            _shapeOneRolling = true;
            _shapeTwoRolling = true;
            _shapeThreeRolling = true;

            StartCoroutine(ShapeOneRandomImage());
            StartCoroutine(ShapeTwoRandomImage());
            StartCoroutine(ShapeThreeRandomImage());
        }

        private void ChangeSlot(SlotType slotType)
        {
            if (slotType == SlotType.One)
            {
                _audioSource.PlayOneShot(_slotSounds[0]);
                _shapeOneRolling = false;
                _shapeOne.sprite = GetSprite(_slotMachineInfo.ShapeOne);
            }

            if (slotType == SlotType.Two)
            {
                _audioSource.PlayOneShot(_slotSounds[1]);
                _shapeTwoRolling = false;
                _shapeTwo.sprite = GetSprite(_slotMachineInfo.ShapeTwo);
            }

            if (slotType == SlotType.Three)
            {
                _audioSource.PlayOneShot(_slotSounds[1]);
                _shapeThreeRolling = false;
                _shapeThree.sprite = GetSprite(_slotMachineInfo.ShapeThree);
            }
        }


        public IEnumerator ShowCongratulation()
        {
            _congratulation.SetActive(true);

            yield return new WaitForSeconds(3);

            _congratulation.SetActive(false);
        }

        private void Update()
        {
            if (!_isPlay)
            {
                return;
            }

            if (_elapseTime >= _slotMachineInfo.ShapeThreeShowInSeconds)
            {
                _elapseTime = 0;
                _isPlay = false;

                var points = _slotMachineInfo.GetPoints();
                if (points == 0)
                {
                    return;
                }


                StartCoroutine(ShowCongratulation());
                return;
            }

            _elapseTime += Time.deltaTime;
        }

        public async void Play()
        {
            if (_isPlay)
            {
                return;
            }

            _isPlay = true;

            await _slotMachinePlayUseCase.Execute();
        }

        private Sprite GetSprite(ShapeType shapeType)
        {
            var shape = _shapes.FirstOrDefault(shape => shape.ShapeType == shapeType);
            if (shape == null)
            {
                throw new Exception($"A shape is not exist for the {shapeType} shapeType ");
            }

            return shape.Image;
        }

        private IEnumerator ShapeOneRandomImage()
        {
            var random = new System.Random();

            while (_shapeOneRolling)
            {
                yield return new WaitForFixedUpdate();
                _shapeOne.sprite = GetSprite(_shapes[random.Next(_shapes.Count())].ShapeType);
            }
        }

        private IEnumerator ShapeTwoRandomImage()
        {
            var random = new System.Random();

            while (_shapeTwoRolling)
            {
                yield return new WaitForFixedUpdate();
                _shapeTwo.sprite = GetSprite(_shapes[random.Next(_shapes.Count())].ShapeType);
            }
        }

        private IEnumerator ShapeThreeRandomImage()
        {
            var random = new System.Random();

            while (_shapeThreeRolling)
            {
                yield return new WaitForFixedUpdate();
                _shapeThree.sprite = GetSprite(_shapes[random.Next(_shapes.Count())].ShapeType);
            }
        }
    }
}

