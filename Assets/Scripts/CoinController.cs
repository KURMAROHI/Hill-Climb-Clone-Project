using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public static CoinController Instance;
    [SerializeField] GameObject parentobject;

    [SerializeField] List<GameObject> Coins = new List<GameObject>();

    [SerializeField] Text CoinText;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void OnEnable()
    {
        // CoinPositionScript.CoinCountEvent += CountingCoins;
    }

    void OnDisable()
    {
        // CoinPositionScript.CoinCountEvent -= CountingCoins;
    }

    void Start()
    {
        if (GameDataManager.Instance != null)
        {
            Debug.Log("TotalAmount|" + GameDataManager.Instance._playerData.TotalAmount);
            CoinText.text= GameDataManager.Instance._playerData.TotalAmount.ToString();
        }

    }

    public void CountingCoins(int Amount = 5)
    {
        Debug.Log("Counting Coins");
        if (GameDataManager.Instance != null)
        {
           // Debug.Log("TotalAmount|" + GameDataManager.Instance._playerData.TotalAmount);
            GameDataManager.Instance.SaveData(Amount);
            CoinText.text= GameDataManager.Instance._playerData.TotalAmount.ToString();

        }
    }

    int oldpos = 90;
    //  [ContextMenu("Coingenerator")]
    public void CoinGenerator()
    {
        int NoofCoins = UnityEngine.Random.Range(5, 10);
        for (int i = 0; i < NoofCoins; i++)
        {
            oldpos += 2;
            int Num = UnityEngine.Random.Range(0, 4);
            GameObject Coin = (GameObject)Instantiate(Coins[Num], parentobject.transform);
            string[] names = Coin.transform.name.Split('(');
            Coin.transform.name = names[0];
            float yValue = parentobject.transform.position.y;
            Coin.transform.localPosition = new Vector3(oldpos, yValue + 10, 0f);
        }
    }

}
