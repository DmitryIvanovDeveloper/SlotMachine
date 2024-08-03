using UnityEngine;
using Zenject;

using SlotMachine.Business.Domain.Common.UseCases;

namespace SlotMachine.Game.Common
{
    public class DataLoader : MonoBehaviour
    {
        private LoadDataUseCase _loadDataUseCase;

        [Inject]
        public void Construct(LoadDataUseCase loadDataUseCase)
        {
            _loadDataUseCase = loadDataUseCase;

        }
        // Use this for initialization
        void Awake()
        {
            _loadDataUseCase.Execute();
        }
    }
}


