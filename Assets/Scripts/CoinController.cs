using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController Instance;
    [SerializeField] GameObject parentobject;

    [SerializeField] List<GameObject> Coins = new List<GameObject>();



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void OnEnable()
    {
        CoinPositionScript.CoinCountEvent += CountingCoins;
    }

    void OnDisable()
    {
        CoinPositionScript.CoinCountEvent -= CountingCoins;
    }

    public void CountingCoins(int Amount = 5)
    {
        Debug.Log("Counting Coins");
    }

    [ContextMenu("Coingenerator")]
    public void CoinGenerator()
    {
        int Num = UnityEngine.Random.Range(0, 4);
        GameObject Coin = (GameObject)Instantiate(Coins[Num], parentobject.transform);
        string[] names = Coin.transform.name.Split('(');
        Coin.transform.name = names[0];
        float yValue = parentobject.transform.position.y;
        Coin.transform.localPosition = new Vector3(90, yValue + 10, 0f);
    }

}
