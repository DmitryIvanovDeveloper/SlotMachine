using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System.Collections;

using SlotMachine.Business.Domain.Health;
using SlotMachine.Business.Domain.Health.UseCases;

namespace SlotMachine.Game.Domain.Health
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private Image _healthSlider;

        private IHealthInfo _healthInfo;

        private HealthStartRepairUseCase _healthRepairUseCase;

        [Inject]
        public void Construct(IHealthInfo healthInfo, HealthStartRepairUseCase healthRepairUseCase)
        {
            _healthInfo = healthInfo;
            _healthRepairUseCase = healthRepairUseCase;
            _healthInfo.OnHealtChanged += UpdateView;
        }

        private async void Start()
        {
            await _healthRepairUseCase.Execute();
        }

        private void UpdateView()
        {
            _healthSlider.fillAmount = (float)_healthInfo.HealthInPercentage / 100f;
        }
    }
}

