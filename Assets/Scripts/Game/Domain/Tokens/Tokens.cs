using TMPro;
using UnityEngine;
using Zenject;

using SlotMachine.Business.Domain.Tokens;
using SlotMachine.Business.Domain.Tokens.UseCase;

namespace SlotMachine.Game.Domain.Tokens
{
    public class Tokens : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _tokens;

        private ITokensInfo _tokensInfo;
        private TokensAddUseCase _tokensAddUseCase;

        [Inject]
        public void Construct(ITokensInfo tokensInfo, TokensAddUseCase tokensAddUseCase)
        {
            _tokensInfo = tokensInfo;
            _tokensAddUseCase = tokensAddUseCase;
        }

        private void Start()
        {
            _tokensInfo.OnTokensChanged += UpdateView;
            UpdateView();
        }

        public void UpdateView()
        {
            _tokens.text = $"{_tokensInfo.Num}";
        }

        public void OnTap()
        {
           _tokensAddUseCase.Execute();
        }
    }
}
