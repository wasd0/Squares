using System;
using System.IO;
using Scripts.Data;
using UnityEngine;

namespace Scripts.MonoBehaviours
{
    public class GameDataService : MonoBehaviour
    {
        private string savePath;
        private const string saveFileName = "globalData.json";

        private GameDataStruct _data;


        public void SaveToJSON(GameDataStruct data)
        {
            string json = JsonUtility.ToJson(data);

            try
            {
                File.WriteAllText(savePath, json);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public GameDataStruct LoadFromJSON()
        {
            if (!File.Exists(savePath))
            {
                Debug.LogWarning("Data has been created and loaded");
                SaveToJSON(_data);
            }

            try
            {
                string json = File.ReadAllText(savePath);
                _data = JsonUtility.FromJson<GameDataStruct>(json);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            return _data;
        }

        public void Init()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            savePath = Path.Combine(Application.persistentDataPath, saveFileName);
#else
            savePath = Path.Combine(Application.dataPath, saveFileName);
#endif

            LoadFromJSON();
        }

        private void OnApplicationQuit()
        {
            SaveToJSON(_data);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (Application.platform == RuntimePlatform.Android)
                SaveToJSON(_data);
        }
    }
}
