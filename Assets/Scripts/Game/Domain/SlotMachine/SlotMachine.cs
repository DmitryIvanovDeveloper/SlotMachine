using UnityEngine;
using Zenject;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;

using SlotMachine.Game.Domain.SlotMachine.Events;
using SlotMachine.Business.Domain.SlotMachine;
using SlotMachine.Business.Common;
using System.Collections;

namespace SlotMachine.Game.Domain.SlotMachine
{
    public class SlotMachine : MonoBehaviour
    {
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

        private SlotMachinePlayEvent _slotMachinePlayEvent;
        private ISlotMachineInfo _slotMachineInfo;

        private float _elapseTime;
        private bool _isPlay;

        [Inject]
        public void Construct(ISlotMachineInfo slotMachineInfo , SlotMachinePlayEvent slotMachinePlayEvent)
        {
            _slotMachinePlayEvent = slotMachinePlayEvent;
            _slotMachineInfo = slotMachineInfo;
        }

        public void StartGame()
        {
            _isPlay = true;

            StartCoroutine(ShapeOneRandomImage());
            StartCoroutine(ShapeTwoRandomImage());
            StartCoroutine(ShapeThreeRandomImage());
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

            await _slotMachinePlayEvent.Notify();
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

            while (_elapseTime < _slotMachineInfo.ShapeOneShowInSeconds)
            {
                yield return new WaitForSeconds(1 / 2);
                _shapeOne.sprite = GetSprite(_shapes[random.Next(_shapes.Count())].ShapeType);
            }

            _shapeOne.sprite = GetSprite(_slotMachineInfo.ShapeOne);
        }

        private IEnumerator ShapeTwoRandomImage()
        {
            var random = new System.Random();

            while (_elapseTime < _slotMachineInfo.ShapeTwoShowInSeconds)
            {
                yield return new WaitForSeconds(1 / 2);
                _shapeTwo.sprite = GetSprite(_shapes[random.Next(_shapes.Count())].ShapeType);
            }

            _shapeTwo.sprite = GetSprite(_slotMachineInfo.ShapeTwo);
        }

        private IEnumerator ShapeThreeRandomImage()
        {
            var random = new System.Random();

            while (_elapseTime < _slotMachineInfo.ShapeThreeShowInSeconds)
            {
                yield return new WaitForSeconds(1 / 2);
                _shapeThree.sprite = GetSprite(_shapes[random.Next(_shapes.Count())].ShapeType);
            }

            _shapeThree.sprite = GetSprite(_slotMachineInfo.ShapeThree);
        }
    }
}

