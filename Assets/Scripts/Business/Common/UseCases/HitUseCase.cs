using SlotMachine.Business.Domain.Health.UseCases;
using SlotMachine.Business.Domain.State.UseCase;
using SlotMachine.Business.Domain.Tokens.UseCase;
using UnityEngine;

namespace SlotMachine.Business.Common.UseCases
{
    public class HitUseCase
    {
        private HealthTryDamageUseCase _healthTryDamageUseCase;
        private StateAddDamageUseCase _stateAddDamageUseCase;
        private TokensAddUseCase _tokensAddUseCase;

        public HitUseCase(
            HealthTryDamageUseCase healthTryDamageUseCase,
            StateAddDamageUseCase stateAddDamageUseCase,
            TokensAddUseCase tokensAddUseCase
        )
        {
            _healthTryDamageUseCase = healthTryDamageUseCase;
            _stateAddDamageUseCase = stateAddDamageUseCase;
            _tokensAddUseCase = tokensAddUseCase;
        }

        public bool Execute()
        {
            var isSuccess = _healthTryDamageUseCase.Execute();
            if (!isSuccess)
            {
                return isSuccess;
            }

            _stateAddDamageUseCase.Execute();
            _tokensAddUseCase.Execute();

            return isSuccess;
        }
    }
}
