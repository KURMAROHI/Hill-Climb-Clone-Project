using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

#if UNITY_KK_WINDOWS
        Debug.LogError("Application.path|" + Application.persistentDataPath);
#elif KK_UNITY_ANDROID
        Debug.LogError("Application.path|" + Application.persistentDataPath);
#endif
    }
}

public class PlayerData
{
        public int TotalAmount;
}
