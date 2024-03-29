using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class DriveCar : MonoBehaviour
{
    [SerializeField] Rigidbody2D FrontTire;
    [SerializeField] Rigidbody2D BackTire;
    [SerializeField] Rigidbody2D Car;

    [SerializeField] float Speed = 150f;
    [SerializeField] float RotationSpeed = 300f;

    private float MoveInput;
    void Start()
    {

    }


    void Update()
    {
        MoveInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        BackTire.AddTorque(-MoveInput * Speed * Time.fixedDeltaTime);
        FrontTire.AddTorque(-MoveInput * Speed * Time.fixedDeltaTime);
        Car.AddTorque(-MoveInput * RotationSpeed * Time.fixedDeltaTime);
    }
}
