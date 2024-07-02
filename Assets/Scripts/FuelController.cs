using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class FuelController : MonoBehaviour
{
    public static FuelController Instance;
    [SerializeField] Image _FuelImage;

    [Range(0.1f, 20f)]
    [SerializeField] float fuelDrainSpeed = 1f;

    [SerializeField] float MaxFuelAmount = 100f;

    [SerializeField] Gradient fuelgradient;
    [SerializeField] CanvasGroup FuelLowSignal;

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
        // CoinPositionScript.FuelFullEvent += SetFuelFull;
    }
    void OnDisable()
    {
        //CoinPositionScript.FuelFullEvent -= SetFuelFull;
    }
    void Start()
    {
        CurrentFuelAmount = MaxFuelAmount;
        UpdateFuelUI();
    }

    public void SetFuelFull()
    {
        if (Lowfueltween != null)
        {
            Lowfueltween.Kill();
        }
        FuelLowSignal.alpha = 0f;
        isfading = false;
        // Debug.LogError("Fuel Full Event Calling");
        CurrentFuelAmount = MaxFuelAmount;
        UpdateFuelUI();
    }

    // Update is called once per frame

    public bool ISfuelAvilable = true;
    void Update()
    {
        if (ISfuelAvilable)
        {
            CurrentFuelAmount -= Time.deltaTime * fuelDrainSpeed;
            UpdateFuelUI();
        }
        else if (PlayerPrefs.GetInt("OnGameEnd", 0) == 0)
        {
            PlayerPrefs.SetInt("OnGameEnd", 1);
            DriveCar.Instance.IsStartMoving = false;
        }
    }

    void UpdateFuelUI()
    {
        _FuelImage.fillAmount = (CurrentFuelAmount / MaxFuelAmount);
        _FuelImage.color = fuelgradient.Evaluate(_FuelImage.fillAmount);

        if (_FuelImage.fillAmount == 0f)
        {
            ISfuelAvilable = false;
            if (Lowfueltween != null)
            {
                Lowfueltween.Kill();
            }
            FuelLowSignal.alpha = 0f;
            Debug.LogError("fuel over");
            if (Input.GetMouseButton(0))
            {
                StartCoroutine(TakeScreenShot());
            }
        }
        else if (_FuelImage.fillAmount > 0.1f && _FuelImage.fillAmount < 0.35f)
        {
            if (!isfading)
            {
                isfading = true;
                SetFadeAnimation();
            }
        }
    }


    // Checking the Screen Shot
    IEnumerator TakeScreenShot()
    {
        yield return new WaitForEndOfFrame();
        ScreenCapture.CaptureScreenshot("screenshot.png", 5);
        Debug.Log("Taken Screen Shot");
    }

    public void FuelGeneretor(float oldpos = 90f)
    {
        GameObject FuelObject = (GameObject)Instantiate(Fuel, parentobject.transform);
        string[] names = FuelObject.transform.name.Split('(');
        FuelObject.transform.name = names[0];
        float yValue = parentobject.transform.position.y;
        FuelObject.transform.localPosition = new Vector3(oldpos, yValue + 10, 0f);
    }

    bool isfading = false;
    Tween Lowfueltween = null;
    void SetFadeAnimation()
    {
        FuelLowSignal.alpha = 1f;
        Lowfueltween = FuelLowSignal.DOFade(0.1f, 0.5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
