using UnityEngine;
using Zenject;

using SlotMachine.Business.Domain.Player;
using SlotMachine.Business.Domain.Player.UseCases;
using TMPro;

namespace SlotMachine.Game.Domain.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private GameObject _arrested;

        [SerializeField]
        private TextMeshProUGUI _timer;

        private IPlayerInfo _playerInfo;

        private PlayerLoadDataUseCase _playerLoadDataUseCase;

        [Inject]
        public void Construct(IPlayerInfo playerInfo, PlayerLoadDataUseCase playerLoadDataUseCase )
        {
            _playerInfo = playerInfo;
            _playerLoadDataUseCase = playerLoadDataUseCase;
        }

        private async void Awake()
        {
            _playerInfo.OnArrestTimerUpdate += UpdateTimer;
            await _playerLoadDataUseCase.Execute();

        }

        private void Start()
        {
            _arrested.SetActive(_playerInfo.IsArrested);
        }

        private void UpdateTimer()
        {
            _timer.text = _playerInfo.GetLiftArrestTime();
        }
    }
}
