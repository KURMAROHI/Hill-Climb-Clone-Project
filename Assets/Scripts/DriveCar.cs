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

    private float MoveInput;
    void Start()
    {

    }


    void Update()
    {
        MoveInput = Input.GetAxisRaw("Horizontal");



#if KK_UNITY_WINDOWS || UNITY_EDITOR
        CheckingMousepos();
#elif KK_UNITY_ANDROID
        CheckingTouch();
#endif
    }

    void FixedUpdate()
    {
        BackTire.AddTorque(-MoveInput * Speed * Time.fixedDeltaTime);
        FrontTire.AddTorque(-MoveInput * Speed * Time.fixedDeltaTime);
        Car.AddTorque(-MoveInput * RotationSpeed * Time.fixedDeltaTime);
    }

    void CheckingMousepos()
    {
        if (Input.mousePosition.x < (Screen.width / 2f - 100f) && Input.mousePosition.x > 0f)
        {
            // Debug.LogError("Left half|" + Input.mousePosition.x);

        }
        else if (Input.mousePosition.x > Screen.width / 2 + 100f && Input.mousePosition.x < Screen.width)
        {
            // Debug.LogError("Right half|" + Input.mousePosition.x);
        }
    }

    void CheckingTouch()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.position.x > 0f && touch.position.x < (Screen.width / 2 - 100f))
        {

        }
        else if (touch.position.x > Screen.width / 2 + 100f && touch.position.x < Screen.width)
        {

        }
    }
}
