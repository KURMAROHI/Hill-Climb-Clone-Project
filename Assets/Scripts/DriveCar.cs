using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;


public class DriveCar : MonoBehaviour
{

    public static DriveCar Instance;
    [SerializeField] Rigidbody2D FrontTire;
    [SerializeField] Rigidbody2D BackTire;
    [SerializeField] public Rigidbody2D Car;
    [SerializeField] float AccelaratorInput, BreakInput;

    int FuelCount = 1;
    float oldFuelPos = 90f, oldcoinpos = 92f;

    [SerializeField] float maxSpeedofCar = 10f;
    [SerializeField] float Accelaration = 10f;
    [SerializeField] float deceleration = 10f;

    float _Carposition;
    public float Distancetravelled = 0f;

    public bool IsStartMoving = false;  // the variable using For Camera Movemnet  After USer Starts playing the Camera Conditions 
    //Offset Conditiomns Will Apply that Are in void Update Function
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    void Start()
    {
        _Carposition = transform.position.x;
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
        if (_Carposition <= transform.position.x)
        {
            Distancetravelled += transform.position.x - _Carposition;
            GameUIController.Instance.SetDistanceTravelled((int)Distancetravelled);
            _Carposition = transform.position.x;
        }


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




#if KK_UNITY_WINDOWs
        BackTire.AddTorque(-MoveInput * Speed * Time.deltaTime);
        FrontTire.AddTorque(-MoveInput * Speed * Time.deltaTime);
       //Car.AddTorque(-MoveInput * RotationSpeed * Time.fixedDeltaTime);
        Car.AddForce(-MoveInput * RotationSpeed * Time.deltaTime);
#elif KK_UNITY_ANDROID
#endif
        CheckCarVelocity();
        if (GameUIController.Instance != null && FuelController.Instance != null)
        {
            if (GameUIController.Instance.iSAccelratorApplied && FuelController.Instance.ISfuelAvilable)
            {
                IsStartMoving = true;
                float forwardForce = AccelaratorInput * Accelaration * Time.deltaTime;
                BackTire.AddTorque(forwardForce * -1);
                FrontTire.AddTorque(forwardForce * -1);
                Car.AddTorque(forwardForce * -1);
                // Debug.LogError("Before forwardForce|" + forwardForce + "| B  velocity|" + BackTire.velocity.magnitude + "|F velocity|" + FrontTire.velocity.magnitude + "|C velocity|" + Car.velocity.magnitude);
                //Clampmagnitude Will Clamp the magnitude values To the Given Parameter
                BackTire.velocity = Vector2.ClampMagnitude(BackTire.velocity, maxSpeedofCar);
                //.AddForce(forwardForce * transform.right);
                FrontTire.velocity = Vector2.ClampMagnitude(FrontTire.velocity, maxSpeedofCar);
                Car.velocity = Vector2.ClampMagnitude(Car.velocity, maxSpeedofCar);
                //   Debug.Log("After forwardForce|" + forwardForce + "| B  velocity|" + BackTire.velocity.magnitude + "|F velocity|" + FrontTire.velocity.magnitude + "|C velocity|" + Car.velocity.magnitude);
                currentposition = transform.position.x;

            }
            if (GameUIController.Instance.isbreakApplied && FuelController.Instance.ISfuelAvilable)
            {
                IsStartMoving = true;
                float breakForce = BreakInput * deceleration * Time.deltaTime;
                BackTire.AddTorque(breakForce * -1);
                FrontTire.AddTorque(breakForce * -1);
                Car.AddTorque(breakForce * -1);
                //Clampmagnitude Will Clamp the magnitude values To the Given Parameter
                BackTire.velocity = Vector2.ClampMagnitude(BackTire.velocity, maxSpeedofCar);
                FrontTire.velocity = Vector2.ClampMagnitude(BackTire.velocity, maxSpeedofCar);
                Car.velocity = Vector2.ClampMagnitude(BackTire.velocity, maxSpeedofCar);
            }

        }

        if (PlayerPrefs.GetInt("OnGameEnd", 0) == 1)
        {
            CollisionChek.HeadCollision?.Invoke();
        }
    }



    void CheckInput()
    {
        if (GameUIController.Instance != null)
        {
            if (GameUIController.Instance.iSAccelratorApplied)
            {
                AccelaratorInput = 1f;
            }
            if (GameUIController.Instance.isbreakApplied)
            {
                BreakInput = -1f;
            }

        }
    }

    [Header("Distance TO move Back variable")]
    [SerializeField] float DistanceMovedback = 50f;
    float currentposition = 50f;
    //     void Update()
    //     {

    // #if KK_UNITY_WINDOWs
    //         BackTire.AddTorque(-MoveInput * Speed * Time.fixedDeltaTime);
    //         FrontTire.AddTorque(-MoveInput * Speed * Time.fixedDeltaTime);
    //        //Car.AddTorque(-MoveInput * RotationSpeed * Time.fixedDeltaTime);
    //         Car.AddForce(-MoveInput * RotationSpeed * Time.fixedDeltaTime);
    // #elif KK_UNITY_ANDROID
    // #endif
    //         CheckCarVelocity();
    //         if (GameUIController.Instance != null && FuelController.Instance != null)
    //         {
    //             if (GameUIController.Instance.iSAccelratorApplied && FuelController.Instance.ISfuelAvilable)
    //             {

    //                 float forwardForce = AccelaratorInput * Accelaration * Time.fixedDeltaTime;
    //                 BackTire.AddTorque(forwardForce * -1);
    //                 FrontTire.AddTorque(forwardForce * -1);
    //                 Car.AddTorque(forwardForce * -1);
    //                 // Debug.LogError("Before forwardForce|" + forwardForce + "| B  velocity|" + BackTire.velocity.magnitude + "|F velocity|" + FrontTire.velocity.magnitude + "|C velocity|" + Car.velocity.magnitude);
    //                 //Clampmagnitude Will Clamp the magnitude values To the Given Parameter
    //                 BackTire.velocity = Vector2.ClampMagnitude(BackTire.velocity, maxSpeedofCar);
    //                 //.AddForce(forwardForce * transform.right);
    //                 FrontTire.velocity = Vector2.ClampMagnitude(FrontTire.velocity, maxSpeedofCar);
    //                 Car.velocity = Vector2.ClampMagnitude(Car.velocity, maxSpeedofCar);
    //                 //   Debug.Log("After forwardForce|" + forwardForce + "| B  velocity|" + BackTire.velocity.magnitude + "|F velocity|" + FrontTire.velocity.magnitude + "|C velocity|" + Car.velocity.magnitude);
    //                 currentposition = transform.position.x;

    //             }
    //             if (GameUIController.Instance.isbreakApplied && FuelController.Instance.ISfuelAvilable)
    //             {

    //                 float breakForce = BreakInput * Accelaration * Time.fixedDeltaTime;
    //                 BackTire.AddForce(breakForce * transform.right);
    //                 FrontTire.AddForce(breakForce * transform.right);
    //                 Car.AddForce(breakForce * transform.right);
    //                 //Clampmagnitude Will Clamp the magnitude values To the Given Parameter
    //                 BackTire.velocity = Vector2.ClampMagnitude(BackTire.velocity, maxSpeedofCar);
    //                 FrontTire.velocity = Vector2.ClampMagnitude(BackTire.velocity, maxSpeedofCar);
    //                 Car.velocity = Vector2.ClampMagnitude(BackTire.velocity, maxSpeedofCar);
    //             }

    //         }
    //     }


    void CheckCarVelocity()
    {
        //if (Car.velocity.magnitude < 1.0f)
        //Debug.Log("===>" + Car.velocity.magnitude);
    }


    //[SerializeField] int _Width = Screen.width, _Height = Screen.height;
    IEnumerator TakeScreenShot()
    {
        yield return new WaitForEndOfFrame();
        int _Width = Screen.width;
        int _Height = Screen.height;
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
