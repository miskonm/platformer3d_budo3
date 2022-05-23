using System;
using UnityEngine;

namespace Platformer.Infrastructure.SaveLoad.IO
{
    public class JsonPrefsSaveLoadIO : ISaveLoadIO
    {
        public T Read<T>(string key) where T : new()
        {
            string json = PlayerPrefs.GetString(key);
            if (string.IsNullOrEmpty(json))
                return new T();

            try
            {
                return JsonUtility.FromJson<T>(json);
            }
            catch (Exception e)
            {
                return new T();
            }
        }

        public void Write<T>(T obj, string key)
        {
            string json = JsonUtility.ToJson(obj);
            PlayerPrefs.SetString(key, json);
        }
    }
}