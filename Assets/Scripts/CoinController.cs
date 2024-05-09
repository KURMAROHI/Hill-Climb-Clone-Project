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
    int NoofDigits;



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

            string AmountString = GameDataManager.Instance._playerData.TotalAmount.ToString();
            NoofDigits = AmountString.Length;
            Debug.Log("TotalAmount|" + GameDataManager.Instance._playerData.TotalAmount + "::" + NoofDigits);
            SpliString();
            CoinText.text = GameDataManager.Instance._playerData.TotalAmount.ToString();
        }

    }

    public void CountingCoins(int Amount = 5)
    {
        // Debug.Log("Counting Coins");
        if (GameDataManager.Instance != null)
        {
            // Debug.Log("TotalAmount|" + GameDataManager.Instance._playerData.TotalAmount);
            GameDataManager.Instance.SaveData(Amount);
            CoinText.text = GameDataManager.Instance._playerData.TotalAmount.ToString();

        }
    }


    public float LastCoinPos = 0f;
    public void CoinGenerator(float oldpos = 90f)
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

        LastCoinPos = oldpos;
    }

    // int DigitCount()
    // {
    //     int Amount = GameDataManager.Instance._playerData.TotalAmount;
    //     int Count = 0;
    //     while (Amount != 0)
    //     {
    //         Amount /= 10;
    //         Count++;
    //     }
    //     return Count;
    // }

    void SpliString()
    {
        string AmountString = GameDataManager.Instance._playerData.TotalAmount.ToString();
        Debug.Log("Sub String|" + AmountString.Substring(0, 3) + "::" + AmountString.Length + "::" + NoofDigits / 3 + "::" + NoofDigits % 3);
        string[] substrings = new string[(NoofDigits / 3) + 1];
        int index = NoofDigits % 3;
        if (index != 0)
        {
            substrings[0] = AmountString.Substring(0, index);
        }
        for (int i = 0; i < NoofDigits / 3; i++)
        {
            substrings[i] = AmountString.Substring(index, 3);
            Debug.Log("SubString|" + substrings[i]);
            index += 3;
        }

    }

}
