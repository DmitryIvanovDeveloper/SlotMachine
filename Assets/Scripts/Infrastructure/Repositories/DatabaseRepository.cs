using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;

using SlotMachine.Business.Adapters;
using SlotMachine.Business.Domain.Dtos;
using SlotMachine.Infrastructure.Repository.Adapters;
using SlotMachine.Infrastructure.Repository.Adapters.Responses;
using SlotMachine.Infrastructure.Repository.Dtos;
using UnityEngine;

namespace SlotMachine.Infrastructure.Repository
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private IDatabaseService _databaseService;
        private ILocalStorageRepository _localStorageRepository;

        public DatabaseRepository(
            IDatabaseService databaseService,
            ILocalStorageRepository localStorageRepository
        )
        {
            _databaseService = databaseService;
            _localStorageRepository = localStorageRepository;
        }

        public async UniTask<List<LevelDto>> GetLevels()
        {
            var response = await _databaseService.GetLevels();
            if (response.Status != "200")
            {
                return new List<LevelDto>();
            }

            return MapLevels(response.Data);
        }
        private List<LevelDto> MapLevels(List<ILevelsResponse> levels)
        {
            var dto = new List<LevelDto>();

            Debug.Log(JsonConvert.SerializeObject(levels));

            foreach(var level in levels)
            {
                var levelDto = new LevelDto()
                {
                    TimeInSeconds = level.TimeInSeconds,
                    StartPoliceBeforeEndTimeInSeconds = level.StartPoliceBeforeEndTimeInSeconds,
                    BackgroundImage = level.BackgroundImage,
                    Id = level.Id,
                    PreviewImage = level.PreviewImage,
                };

                var slotMachine = new SlotMachineDto()
                {
                    Id = level.SlotMachine.Id,
                    FullRepairInMinutes = level.SlotMachine.FullRepairInMinutes,
                    MaxHealth = level.SlotMachine.MaxHealth,
                };

                foreach (var state in level.SlotMachine.States)
                {
                    var slotMachineStateDto = new SlotMachineStateDto()
                    {
                        StateType = state.StateType,
                        Image = state.Image,
                    };

                    slotMachine.StatesSlotMachine.Add(slotMachineStateDto);
                }

                levelDto.SlotMachine = slotMachine;

                dto.Add(levelDto);
            }

            return dto;
        }


        public void SaveLevel(Settings.Dtos.LevelDto dto)
        {
            var saveLevelRequest = new SaveLevelRequest()
            {
                TimeInSeconds = dto.TimeInSeconds,
                StartPoliceBeforeEndTimeInSeconds = dto.StartPoliceBeforeEndTimeInSeconds,
                BackgroundImage = dto.BackgroundImage,
                Id = dto.LevelId,
                PreviewImage = dto.PreviewImage,
            };

            var saveSlotMachineRequest = new SaveSlotMachineRequest()
            {
                FullRepairInMinutes = dto.SlotMachine.FullRepairInMinutes,
                MaxHealth = dto.SlotMachine.MaxHealth,
            };

            foreach (var state in dto.SlotMachine.StatesSlotMachine)
            {
                var saveSlotMachineStateRequest = new SaveSlotMachineStateRequest()
                {
                    StateType = state.StateType,
                    Image = state.Image,
                };

                saveSlotMachineRequest.StatesSlotMachine.Add(saveSlotMachineStateRequest);
            }

            saveLevelRequest.SlotMachine = saveSlotMachineRequest;

            var data = JsonConvert.SerializeObject(saveLevelRequest);

            _databaseService.PostLevel(data);
        }

        public async UniTask UpdateTokens()
        {
            var data = JsonConvert.SerializeObject(_localStorageRepository.GetTokens());

            await _databaseService.UpdateTokens("", data);
        }
    }
}


