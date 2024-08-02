using UnityEngine;
using System.Collections;
using Zenject;
using TMPro;

using SlotMachine.Business.Domain.StageTimer;
using SlotMachine.Business.Domain.StageTimer.Events;
using SlotMachine.Business.Domain.Police;
using static SlotMachine.Business.Domain.Police.Police;

namespace SlotMachine.Game.Domain.StageTimer
{
    public class StageTimer : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _timer;

        private IStageTimerInfo _stageTimerInfo;
        private StageTimerStartEvent _stageTimerStartEvent;
        private IPoliceInfo _policeInfo;

        [Inject]
        public void Construct(
            IStageTimerInfo stageTimerInfo,
            StageTimerStartEvent stageTimerStartEvent,
            IPoliceInfo policeInfo
        )
        {
            _stageTimerInfo = stageTimerInfo;
            _stageTimerStartEvent = stageTimerStartEvent;
            _policeInfo = policeInfo;
        }

        private async void Start()
        {
            _stageTimerInfo.OnUpdate += UpdateView;
            _policeInfo.OnDoWork += ShowTimer;

            await _stageTimerStartEvent.Notify();
        }

        private void UpdateView()
        {
            _timer.text = _stageTimerInfo.GetLeftTime();
        }

        private void ShowTimer()
        {
            _timer.enabled = true;
        }
    }
}


