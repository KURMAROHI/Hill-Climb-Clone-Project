using System;
using UnityEngine;
using UnityEngine.UI;

public class FuelController : MonoBehaviour
{
    public static FuelController Instance;
    [SerializeField] Image _FuelImage;

    [Range(0.1f, 5f)]
    [SerializeField] float fuelDrainSpeed = 1f;

    [SerializeField] float MaxFuelAmount = 100f;

    [SerializeField] Gradient fuelgradient;

    float CurrentFuelAmount;

    [SerializeField] GameObject Fuel;
    [SerializeField] GameObject parentobject;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void OnEnable()
    {
        CoinPositionScript.FuelFullEvent += SetFuelFull;
    }
    void OnDisable()
    {
        CoinPositionScript.FuelFullEvent -= SetFuelFull;
    }
    void Start()
    {
        CurrentFuelAmount = MaxFuelAmount;
        UpdateFuelUI();
    }

    public void SetFuelFull()
    {
        Debug.LogError("Fuel Full Event Calling");
        CurrentFuelAmount = MaxFuelAmount;
        UpdateFuelUI();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentFuelAmount -= Time.deltaTime * fuelDrainSpeed;
        UpdateFuelUI();
    }

    void UpdateFuelUI()
    {
        _FuelImage.fillAmount = (CurrentFuelAmount / MaxFuelAmount);
        _FuelImage.color = fuelgradient.Evaluate(_FuelImage.fillAmount);
    }

    public void FuelGeneretor()
    {

        GameObject FuelObject = (GameObject)Instantiate(Fuel, parentobject.transform);
        string[] names = FuelObject.transform.name.Split('(');
        FuelObject.transform.name = names[0];
        float yValue = parentobject.transform.position.y;
        FuelObject.transform.localPosition = new Vector3(90, yValue + 10, 0f);
    }
}
