using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.Networking;
using UnityEngine;
using System.Collections.Generic;
using Hare.Infrastructure.Services.Dtos;
using SlotMachine.Infrastructure.Repository.Adapters;
using Cysharp.Threading.Tasks;

using SlotMachine.Infrastructure.Repository.Adapters.Responses;
using SlotMachine.Infrastructure.Service.Dtos.Responses;
using System.Linq;

namespace Hare.Infrastructure.Services
{
    public class DatabaseService : IDatabaseService
    {

        //private string _url = "https://stage.for-game.ru";
        private string _url = "http://localhost:10000/api";

        public async UniTask<IResponse<List<ILevelsResponse>>> GetLevels()
        {

            try
            {
                var www = new UnityWebRequest($"{_url}/levels", "GET");

                www.downloadHandler = new DownloadHandlerBuffer();
                //www.SetRequestHeader("x-api-key", accessToken);
              

            var operation = www.SendWebRequest();

                await UniTask.WaitUntil(() => operation.isDone);

                if (www.result == UnityWebRequest.Result.Success)
                {
                    Debug.LogFormat($"status = {UnityWebRequest.Result.Success}");
                }

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogWarning($"error = {www.error}");
                }

                var userData = JsonConvert.DeserializeObject<List<LevelsResponse>>(www.downloadHandler.text);

                 return new Response<List<ILevelsResponse>>("200", userData.Cast<ILevelsResponse>().ToList());

            }
            catch (HttpRequestException e)
            {
                throw new Exception(e.Message);
            }
        }


        public async UniTask PostLevel(string jsonData)
        {
            try
            {
                Debug.Log(jsonData);
                var www = new UnityWebRequest($"{_url}/levels", "POST");

                var data = Encoding.UTF8.GetBytes(jsonData);
                www.uploadHandler = new UploadHandlerRaw(data);
                www.downloadHandler = new DownloadHandlerBuffer();
                www.SetRequestHeader("Content-Type", "application/json");
                www.SetRequestHeader("charset", "utf-8");
                //www.SetRequestHeader("x-api-key", accessToken);

                var operation = www.SendWebRequest();

                await UniTask.WaitUntil(() => operation.isDone);

                if (www.result == UnityWebRequest.Result.Success)
                {
                    Debug.LogFormat($"status = {UnityWebRequest.Result.Success}");
                }

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogWarning($"error = {www.error}");
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        //public async Task<Response<GameData>> UpdateData(string jsonData, string accessToken)
        //{
        //    try
        //    {
        //        var data = Encoding.UTF8.GetBytes(jsonData);

        //        var www = new UnityWebRequest($"{_url}/updatePlayerState", "POST");

        //        www.uploadHandler = new UploadHandlerRaw(data);
        //        www.downloadHandler = new DownloadHandlerBuffer();
        //        www.SetRequestHeader("Content-Type", "application/json");
        //        www.SetRequestHeader("x-api-key", accessToken);

        //        var operation = www.SendWebRequest();

        //        while (!operation.isDone)
        //        {
        //            await Task.Yield();
        //        }

        //        if (www.result == UnityWebRequest.Result.Success)
        //        {
        //            Debug.LogFormat($"status = {UnityWebRequest.Result.Success}");
        //        }

        //        if (www.result != UnityWebRequest.Result.Success)
        //        {
        //            Debug.LogWarning($"error = {www.error}");

        //            return new Response<GameData>("400", null);
        //        }

        //        var userData = JsonConvert.DeserializeObject<GameData>(www.downloadHandler.text);
        //        return new Response<GameData>("200", userData);

        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Console.WriteLine("\nException Caught!");
        //        Console.WriteLine("Message :{0} ", e.Message);

        //        return new Response<GameData>("400", null);
        //    }
        //}

        public async Task PostLinkId(long id, string accessToken)
        {
            try
            {
                var www = new UnityWebRequest($"{_url}/links/{id}", "POST");

                www.downloadHandler = new DownloadHandlerBuffer();
                www.SetRequestHeader("x-api-key", accessToken);

                var operation = www.SendWebRequest();

                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (www.result == UnityWebRequest.Result.Success)
                {
                    Debug.LogFormat($"status = {UnityWebRequest.Result.Success}");
                }

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogWarning($"error = {www.error}");
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        public void SaveCoins(int numCoins)
        {
            throw new NotImplementedException();
        }

        public async UniTask UpdateTokens(string accessToken, string jsonData)
        {
            try
            {
                var www = new UnityWebRequest($"{_url}/tokens", "POST");

                var data = Encoding.UTF8.GetBytes(jsonData);
                www.uploadHandler = new UploadHandlerRaw(data);
                www.downloadHandler = new DownloadHandlerBuffer();
                www.SetRequestHeader("Content-Type", "application/json");
                www.SetRequestHeader("charset", "utf-8");
                www.SetRequestHeader("x-api-key", accessToken);

                var operation = www.SendWebRequest();

                await UniTask.WaitUntil(() => operation.isDone);

                if (www.result == UnityWebRequest.Result.Success)
                {
                    Debug.LogFormat($"status = {UnityWebRequest.Result.Success}");
                }

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogWarning($"error = {www.error}");
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
