using TMPro;
using UnityEngine;
using Zenject;

using SlotMachine.Business.Domain.Tokens;
using SlotMachine.Game.Domain.Tokens.Events;

namespace SlotMachine.Game.Domain.Tokens
{
    public class Tokens : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _tokens;

        private ITokensInfo _tokensInfo;
        private TokensAddEvent _tokensAddEvent;

        [Inject]
        public void Construct(ITokensInfo tokensInfo, TokensAddEvent tokensAddEvent)
        {
            _tokensInfo = tokensInfo;
            _tokensAddEvent = tokensAddEvent;
        }

        private void Start()
        {
            UpdateView();
        }

        public void UpdateView()
        {
            _tokens.text = $"{_tokensInfo.Num}";
        }

        public async void OnTap()
        {
           await _tokensAddEvent.Notify();
        }
    }
}
