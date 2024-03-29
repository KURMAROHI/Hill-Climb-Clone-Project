using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMoving : MonoBehaviour
{

      [SerializeField] GameObject FrontTire;
      [SerializeField] WheelJoint2D FrontTireWheelJoint2D;
      [SerializeField] GameObject BackTire;
      [SerializeField] WheelJoint2D BackTireWheelJoint2D;

      JointMotor2D BackMotor;
      JointMotor2D FrontMotor;

      void OnEnable()
      {
            BackTireWheelJoint2D = BackTire.GetComponent<WheelJoint2D>();
            FrontTireWheelJoint2D = FrontTire.GetComponent<WheelJoint2D>();
            FrontTireWheelJoint2D.useMotor = true;
            BackTireWheelJoint2D.useMotor = true;
            BackMotor = BackTireWheelJoint2D.motor;
            FrontMotor = FrontTireWheelJoint2D.motor;
      }

      public void MoveTheCar()
      {
            Debug.Log("MoveTheCar");
            BackMotor.motorSpeed = 200f;
            FrontMotor.motorSpeed = 200f;
            BackTireWheelJoint2D.motor = BackMotor;
            FrontTireWheelJoint2D.motor = FrontMotor;
      }

      public void StopTheCar()
      {
            Debug.Log("StopTheCar");
            BackTireWheelJoint2D.breakForce = 100f;
            FrontTireWheelJoint2D.breakForce = 100f;
      }



}
