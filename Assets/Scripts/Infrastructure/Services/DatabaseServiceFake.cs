using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Hare.Infrastructure.Services.Dtos;
using Newtonsoft.Json;

using SlotMachine.Infrastructure.Repository.Adapters;
using SlotMachine.Infrastructure.Repository.Adapters.Responses;
using SlotMachine.Infrastructure.Service.Dtos.Responses;
using UnityEngine;

namespace SlotMachine.Infrastructure.Services
{
    public class DatabaseServiceFake : IDatabaseService
    {

        public void SaveCoins(int numCoins)
        {
            throw new System.NotImplementedException();
        }

        public async UniTask<IResponse<List<ILevelsResponse>>> GetLevels()
        {
            await UniTask.WaitForSeconds(1);

            var levelsData = PlayerPrefs.GetString("Levels");
            if (string.IsNullOrEmpty(levelsData))
            {
                return new Response<List<ILevelsResponse>>("400", null);
            }

            var levels = JsonConvert.DeserializeObject<List<string>>(levelsData);

            var a = new List<ILevelsResponse>();

            foreach (string levelData in levels)
            {
                var serializedObject = JsonConvert.DeserializeObject<LevelsResponse>(levelData);
                a.Add(serializedObject);
            }

            return new Response<List<ILevelsResponse>>("200", a);
        }

        public async UniTask PostLevel(string data)
        {
            await UniTask.WaitForSeconds(0);

            var levelsData = PlayerPrefs.GetString("Levels");
            if (string.IsNullOrEmpty(levelsData))
            {
                var newLevels = new List<string>()
                {
                    data
                };

                PlayerPrefs.SetString("Levels", JsonConvert.SerializeObject(newLevels));
                return;
            }

            var levels = JsonConvert.DeserializeObject<List<string>>(levelsData);

            levels.Add(data);

            PlayerPrefs.SetString("Levels", JsonConvert.SerializeObject(levels));
        }
    }
}

