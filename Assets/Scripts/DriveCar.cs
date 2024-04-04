using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DriveCar : MonoBehaviour
{
    [SerializeField] Rigidbody2D FrontTire;
    [SerializeField] Rigidbody2D BackTire;
    [SerializeField] Rigidbody2D Car;

    [SerializeField] float Speed = 200f;
    [SerializeField] float RotationSpeed = 100f;

    [SerializeField] float MoveInput;
    [SerializeField] float AccelaratorInput, BreakInput;

    int FuelCount = 1;
    float oldFuelPos = 90f, oldcoinpos = 92f;

    void Start()
    {
        if (CoinController.Instance != null)
        {
            CoinController.Instance.CoinGenerator(92f);
        }
        if (FuelController.Instance != null)
        {
            FuelController.Instance.FuelGeneretor();
        }
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
          //  StartCoroutine(TakeScreenShot());
        }

        if (Input.GetMouseButton(1))
        {
           // StartCoroutine(TakeScreenShotUsingInternalMethod());
        }
#if KK_UNITY_WINDOWS
        //CheckingMousepos();
        MoveInput = Input.GetAxisRaw("Horizontal");
#elif KK_UNITY_ANDROID
        //  CheckingTouch();
        CheckInput();
#endif

        if (transform.position.x > oldFuelPos && FuelController.Instance != null && FuelController.Instance.ISfuelAvilable)
        {
            FuelCount++;
            oldFuelPos = oldFuelPos * FuelCount;
            FuelController.Instance.FuelGeneretor(oldFuelPos);
        }
        if (transform.position.x > oldcoinpos / 2 && CoinController.Instance != null &&
            FuelController.Instance != null && FuelController.Instance.ISfuelAvilable)
        {
            oldcoinpos = oldcoinpos + 50f;
            CoinController.Instance.CoinGenerator(oldcoinpos);
        }
    }



    void CheckInput()
    {
        if (GameUIController.Instance != null)
        {
            if (GameUIController.Instance.iSAccelratorApplied)
            {
                AccelaratorInput = -1f;
            }
            if (GameUIController.Instance.isbreakApplied)
            {
                BreakInput = 1f;
            }

        }
    }

    void FixedUpdate()
    {

#if KK_UNITY_WINDOWs
        BackTire.AddTorque(-MoveInput * Speed * Time.fixedDeltaTime);
        FrontTire.AddTorque(-MoveInput * Speed * Time.fixedDeltaTime);
        Car.AddTorque(-MoveInput * RotationSpeed * Time.fixedDeltaTime);
#elif KK_UNITY_ANDROID

#endif
        if (GameUIController.Instance != null && FuelController.Instance != null)
        {
            if (GameUIController.Instance.iSAccelratorApplied && FuelController.Instance.ISfuelAvilable)
            {
                BackTire.AddTorque(AccelaratorInput * Speed * Time.fixedDeltaTime);
                FrontTire.AddTorque(AccelaratorInput * Speed * Time.fixedDeltaTime);
                Car.AddTorque(AccelaratorInput * RotationSpeed * Time.fixedDeltaTime);
            }
            if (GameUIController.Instance.isbreakApplied && FuelController.Instance.ISfuelAvilable)
            {
                BackTire.AddTorque(BreakInput * Speed * Time.fixedDeltaTime);
                FrontTire.AddTorque(BreakInput - MoveInput * Speed * Time.fixedDeltaTime);
                Car.AddTorque(BreakInput * RotationSpeed * Time.fixedDeltaTime);
            }

        }
    }

//[SerializeField] int _Width = Screen.width, _Height = Screen.height;
    IEnumerator TakeScreenShot()
    {
        yield return new WaitForEndOfFrame();
        int _Width = Screen.width;
        int  _Height = Screen.height;
        Texture2D ScreenShot = new Texture2D(1136, 640, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, _Width, _Height);
        ScreenShot.ReadPixels(rect, 0, 0);
        ScreenShot.Apply();

        byte[] bytearray = ScreenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + "/ScreenShot.png", bytearray);
        Debug.LogError("Taken Screen Shot");
    }

    IEnumerator TakeScreenShotUsingInternalMethod()
    {
        yield return new WaitForEndOfFrame();
        ScreenCapture.CaptureScreenshot("ScreenShot1.png");
        Debug.LogError("TakeScreenShotUsingInternalMethod");
    }
}
