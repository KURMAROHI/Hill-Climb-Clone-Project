using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
        // Start is called before the first frame update
        public static GameDataManager Instance;
        string FileName = "USERDTA.json";
        string FullPath;
        public PlayerData _playerData;

        void Awake()
        {
                if (Instance == null)
                {
                        Instance = this;
                }
                _playerData = new PlayerData();
        }
        void OnEnable()
        {

                FullPath = Path.Combine(Application.persistentDataPath, FileName);

                //DirectoryInfo PlayerdirectoryInfo = new DirectoryInfo(FullPath);

                if (File.Exists(FullPath))
                {
                        Debug.LogError("Ok File Exists");
                        Lodadata();
                }
                else
                {
                        File.Create(FullPath);
                        Debug.LogError("File Created");
                }

                // if (PlayerdirectoryInfo.Exists)
                // {
                //         Debug.LogError("Ok File Exists in that Directoryinfo");
                // }
                // else
                // {
                //         Debug.LogError("Ok File DoesnotExists in that Directory");
                //         PlayerdirectoryInfo.Create();
                // }

#if UNITY_KK_WINDOWS
        Debug.LogError("Application.path|" + Application.persistentDataPath);
#elif KK_UNITY_ANDROID
                Debug.LogError("Application.path|" + Application.persistentDataPath);
#endif
        }


        public void SaveData(int Amount = 0)
        {
                _playerData.TotalAmount += Amount;
                string jsondata = JsonUtility.ToJson(_playerData);
               // Debug.LogError("json data|" + jsondata);
                File.WriteAllText(FullPath, jsondata);
        }

        PlayerData playerDataload;
        public void Lodadata()
        {
                string jsondata = File.ReadAllText(FullPath);
                _playerData = JsonUtility.FromJson<PlayerData>(jsondata);
        }
}

[System.Serializable]
public class PlayerData
{
        public int TotalAmount;
}
