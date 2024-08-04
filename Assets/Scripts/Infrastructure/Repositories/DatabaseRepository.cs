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

        public DatabaseRepository(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
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

            foreach(var level in levels)
            {
                var levelDto = new LevelDto()
                {
                    TimeInSeconds = level.TimeInSeconds,
                    StartPoliceBeforeEndTimeInSeconds = level.StartPoliceBeforeEndTimeInSeconds,
                    BackgroundImage = level.BackgroundImage,
                    LevelId = level.LevelId,
                    PreviewImage = level.PreviewImage,
                };

                var slotMachine = new SlotMachineDto()
                {
                    FullRepairInMinutes = level.SlotMachine.FullRepairInMinutes,
                    MaxHealth = level.SlotMachine.MaxHealth,
                };

                foreach (var state in level.SlotMachine.StatesSlotMachine)
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
                LevelId = dto.LevelId,
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

            Debug.Log(data);

            _databaseService.PostLevel(data);
        }
    }
}


