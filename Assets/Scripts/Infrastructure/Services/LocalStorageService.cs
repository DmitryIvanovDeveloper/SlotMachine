﻿using System;
using UnityEngine;

using SlotMachine.Infrastructure.Repository.Adapters;
using SlotMachine.Infrastructure.Utils;
using Newtonsoft.Json;

namespace SlotMachine.Infrastructure.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        public delegate int LocalStorage();
        public event LocalStorage OnUpdated;

        private Guid _keyAndroid = new Guid("aa859713-bbd2-447a-9c89-9762c93ad8da");
        private static byte[] _tempBytes = new byte[0];

        private RC4 _rc4;
        private string _filePath = $"SlothMachine";

        private SessionData _sessionData = new SessionData();

        public LocalStorageService()
        {
            _rc4 = new RC4(_keyAndroid);
            _sessionData = Load();
        }

        private SessionData Load()
        {
            try
            {
                if (!PlayerPrefs.HasKey(_filePath))
                {
                    return new SessionData();
                }

                _tempBytes = JsonConvert.DeserializeObject<byte[]>(PlayerPrefs.GetString(_filePath));
                _rc4.Crypt(_tempBytes);
                return DeserializeSessionData(_tempBytes);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void ResetProgress()
        {
            _sessionData = new SessionData();
            SaveSessionData();
        }

        private void SaveSessionData()
        {
            _tempBytes = SerializeSessionData();
            _rc4.Crypt(_tempBytes);

            try
            {
                PlayerPrefs.SetString(_filePath, JsonConvert.SerializeObject(_tempBytes));
                OnUpdated?.Invoke();
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                _tempBytes = null;
            }
        }

        public void SaveCoins(string coins)
        {
            _sessionData.Coins = coins;
            Debug.Log(_sessionData.Coins);
            SaveSessionData();
        }

        private byte[] SerializeSessionData()
        {
            string json = JsonConvert.SerializeObject(_sessionData);
            return System.Text.Encoding.UTF8.GetBytes(json);
        }

        private SessionData DeserializeSessionData(byte[] data)
        {
            var json = System.Text.Encoding.UTF8.GetString(data);
            return JsonConvert.DeserializeObject<SessionData>(json);
        }
    }
}
